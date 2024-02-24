using AutoMapper;
using Pretech.Software.RConfig.Core.Repository.Projects.Abstract;
using Pretech.Software.RConfig.Core.Repository.Projects.Concrete;
using Pretech.Software.RConfig.Crypto.Abstract;
using Pretech.Software.RConfig.UI.Response;
using SQLitePCL;

namespace Pretech.Software.RConfig.UI.Models
{
    public class ProjectModel
    {
        #region Properties
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; }
        public List<ProjectLine> Projects { get; set; }

        private readonly IProjectsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IJsonCrypto _crypto;
        public ProjectModel(IProjectsRepository repository, IMapper mapper, IJsonCrypto crypto)
        {
            _repository = repository;
            _mapper = mapper;
            _crypto = crypto;
        }
        #endregion


        public async Task<ProjectModel> CreateModelAsync()
        {

            try
            {
                var projects = await _repository.AllAsync();
                if (projects.IsSuccess)
                {
                    var dto = _mapper.Map<List<ProjectLine>>(projects.Data);
                    this.Projects = dto;
                    this.IsError = false;
                    this.ErrorMessage = string.Empty;
                }
                else
                {
                    this.Projects = new();
                    this.IsError = true;
                    this.ErrorMessage = projects.Message;
                }
            }
            catch (Exception ex)
            {

                this.ErrorMessage = ex.Message;
                this.IsError = false;
                this.Projects = new();
            }
            return this;
        }
        public async Task<ProjectLine> FindAsync(string id)
        {
            var project = await _repository.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
            if (project.IsSuccess)
            {
                var dto = _mapper.Map<ProjectLine>(project.Data);
                return dto;
            }
            else return null;
        }
        public async Task<bool> CreateProjectAsync(string name, string application)
        {
            try
            {
                var newProject = CreaterProjects.Create(name, application);

                var key = await _crypto.GenerateKeyAsync();
                if (key.IsSuccess)
                {
                    newProject.Key = key.Data;
                    var inserted = await _repository.AddAsync(newProject);
                    return inserted.IsSuccess;

                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteProject(string id)
        {
            var deleteProject = await _repository.DeleteAsync(Guid.Parse(id));
            return deleteProject.IsSuccess;

        }
        public async Task<bool> AddAccessIP(string id, string accessIp)
        {
            var findProject = await _repository.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
            if (findProject.IsSuccess)
            {
                var accessList = findProject.Data.RestrictedList?.Split(";").ToHashSet();
                var added = accessList.Add(accessIp);
                if (added)
                {
                    findProject.Data.RestrictedList = string.Join(";", accessList);

                    var updated = await _repository.UpdateAsync(findProject.Data);
                    if (updated.IsSuccess) return true;
                    else return false;
                }
                else return false;
            }
            else return false;

        }
        public async Task<bool> DeleteAccessIP(string id, string accessIp)
        {
            var findProject = await _repository.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
            if (findProject.IsSuccess)
            {
                var accessList = findProject.Data.RestrictedList?.Split(";").ToHashSet();
                var delete = accessList.Remove(accessIp);
                if (delete)
                {
                    findProject.Data.RestrictedList = string.Join(";", accessList);

                    var updated = await _repository.UpdateAsync(findProject.Data);
                    if (updated.IsSuccess) return true;
                    else return false;
                }
                else return false;
            }
            else return false;

        }
        public async Task<bool> StatusChangeAsync(string id, int status)
        {
            var findProject = await _repository.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
            if (findProject.IsSuccess)
            {
                findProject.Data.Active = status == 1 ? true : false;

                var updated = await _repository.UpdateAsync(findProject.Data);
                if (updated.IsSuccess) return true;
                else return false;
            }
            else return false;
        }
    }
}
