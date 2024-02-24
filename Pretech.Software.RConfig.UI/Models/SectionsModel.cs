using AutoMapper;
using Pretech.Software.RConfig.Core.Repository.Projects.Abstract;
using Pretech.Software.RConfig.Core.Repository.Section.Abstract;
using Pretech.Software.RConfig.Core.Repository.Section.Concrete;
using Pretech.Software.RConfig.Crypto.Abstract;
using Pretech.Software.RConfig.UI.Response;

namespace Pretech.Software.RConfig.UI.Models
{
    public class SectionsModel
    {
        #region Props
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; }

        public List<SectionsLine> SectionsOfProject { get; set; }
        private readonly ISectionRepository _repository;
        private readonly IProjectsRepository _projectRepository;
        private readonly IJsonCrypto _crypto;
        private readonly IMapper _mapper;

        #endregion

        public SectionsModel(ISectionRepository repository, IJsonCrypto crypto, IProjectsRepository projectRepository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
            _crypto = crypto;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<SectionsModel> GetSectionsOfProject(string projectId)
        {
            var pId = Guid.Parse(projectId);
            var querySections = await _repository.QueryAsync(q => q.ProjectId == pId);
            var queryProject = await _projectRepository.FindAsync(pId);
            if (querySections.IsSuccess && queryProject.IsSuccess)
            {
                string projectKey = queryProject.Data.Key;

                foreach (var item in querySections.Data)
                {
                    var rawJson = await _crypto.DecryptAsync(item.Value, projectKey);
                    if (rawJson.IsSuccess)
                    {
                        item.Value = rawJson.Data;
                    }
                }
                var dtoSections = _mapper.Map<List<SectionsLine>>(querySections.Data);
                this.SectionsOfProject = dtoSections;
                this.IsError = false;
                this.ErrorMessage = string.Empty;
            }
            else
            {
                this.SectionsOfProject = new();
                this.IsError = true;
                this.ErrorMessage = querySections.Message;
            }

            return this;

        }

        public async Task<bool> CreateSectionAsync(string projectId, string name, string value)
        {
            try
            {
                var project = await _projectRepository.FindAsync(Guid.Parse(projectId));
                if (project.IsSuccess)
                {
                    var newSection = CreateSection.Create(name, value, projectId);
                    var encryptData = await _crypto.EncryptAsync(value, project.Data.Key);
                    if (encryptData.IsSuccess)
                    {
                        newSection.Value = encryptData.Data;
                        var inserted = await _repository.AddAsync(newSection);
                        return inserted.IsSuccess;
                    }
                    else return false;

                }
                else return false;


            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<bool> DeleteSectionAsync(string sectionId)
        {
            var deleted = await _repository.DeleteAsync(Guid.Parse(sectionId));
            return deleted.IsSuccess;
        }
    }
}
