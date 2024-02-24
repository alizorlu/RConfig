using Pretech.Software.RConfig.Core.DBContext;
using Pretech.Software.RConfig.Core.DBContext.Tables;
using Pretech.Software.RConfig.Core.Repository.Projects.Abstract;

namespace Pretech.Software.RConfig.Core.Repository.Projects.Concrete
{
    public class ProjectRepository : Repository.Base.Repository<TBL_Projects>, IProjectsRepository
    {
        public ProjectRepository(RConfigContext context) : base(context)
        {
        }
    }
}
