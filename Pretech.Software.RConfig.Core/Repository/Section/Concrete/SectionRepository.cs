using Pretech.Software.RConfig.Core.DBContext;
using Pretech.Software.RConfig.Core.DBContext.Tables;
using Pretech.Software.RConfig.Core.Repository.Base;
using Pretech.Software.RConfig.Core.Repository.Section.Abstract;

namespace Pretech.Software.RConfig.Core.Repository.Section.Concrete
{
    public class SectionRepository : Repository<TBL_Sections>, ISectionRepository
    {
        public SectionRepository(RConfigContext context) : base(context)
        {
        }
    }
}
