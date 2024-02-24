using JsonFormatterPlus;
using MediatR;
using Pretech.Software.RConfig.ApiServer.Query.Config;
using Pretech.Software.RConfig.ApiServer.Response;
using Pretech.Software.RConfig.Core.Repository.Projects.Abstract;
using Pretech.Software.RConfig.Core.Repository.Section.Abstract;
using Pretech.Software.RConfig.Core.Response;
using System.Text;

namespace Pretech.Software.RConfig.ApiServer.Handler.Config
{
    public class QueryConfigHandler : IRequestHandler<QueryConfig, ResponseBase<ResponseConfig>>
    {
        private readonly IProjectsRepository _project;
        private readonly ISectionRepository _section;

        public QueryConfigHandler(ISectionRepository section, IProjectsRepository project = null)
        {
            _section = section;
            _project = project;
        }

        public async Task<ResponseBase<ResponseConfig>> Handle(QueryConfig request, CancellationToken cancellationToken)
        {
            ResponseBase<ResponseConfig> result = new();
            try
            {
                var project = await _project.FirstOrDefaultAsync(q => q.Secret == request.Secret && q.Active == true);
                if (project.IsSuccess)
                {
                    #region Control IP Sec
                    if (project.Data.RestrictedList != "*")
                    {
                        var ipSec = project.Data.RestrictedList.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                        bool isAccepted = ipSec.Any(q => q.Equals(request.RequestIp) == true);
                        if (!isAccepted)
                        {
                            result.Error("Your IP address is not authorized to access this document.");
                            return result;
                        }
                    } 
                    #endregion

                    var sections = await _section.QueryAsync(q => q.ProjectId == project.Data.Id);
                    if (sections.IsSuccess)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("{");
                        foreach (var section in sections.Data)
                        {
                            sb.AppendLine($"\"{section.Name}\":\"{section.Value}\",\n");
                        }
                        sb.AppendLine("}");

                        ResponseConfig responseConfig = new ResponseConfig();
                        responseConfig.Value = JsonFormatter.Format(sb.ToString());

                        result.Success(responseConfig);
                    }
                    else result.Error($"Not found sections in {project.Data.Name}");
                }
                else result.Error("Not found project by secret key");
            }
            catch (Exception ex)
            {

                result.Error(ex.ToString());
            }
            return result;
        }
    }
}
