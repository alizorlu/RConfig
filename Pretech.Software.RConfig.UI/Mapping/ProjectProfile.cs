using AutoMapper;
using Pretech.Software.RConfig.Core.DBContext.Tables;
using Pretech.Software.RConfig.UI.Response;

namespace Pretech.Software.RConfig.UI.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<TBL_Projects, ProjectLine>().ReverseMap();
        }
    }
}
