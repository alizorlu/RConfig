using AutoMapper;
using Pretech.Software.RConfig.Core.DBContext.Tables;
using Pretech.Software.RConfig.UI.Response;

namespace Pretech.Software.RConfig.UI.Mapping
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<TBL_Sections, SectionsLine>().ReverseMap();

        }
    }
}
