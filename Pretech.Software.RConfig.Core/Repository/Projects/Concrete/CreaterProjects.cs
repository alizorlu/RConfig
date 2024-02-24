using Pretech.Software.RConfig.Core.DBContext.Tables;

namespace Pretech.Software.RConfig.Core.Repository.Projects.Concrete
{
    public struct CreaterProjects
    {
        public static TBL_Projects Create(string name, string application)
        {
            return new TBL_Projects()
            {
                Active = true,
                Name = name,
                Application = application,
                Create = DateTime.Now.ToUniversalTime(),
                Id = Guid.NewGuid(),
                Secret = Guid.NewGuid().ToString().Replace("-", "").ToUpper(),
                Update = DateTime.Now.ToUniversalTime()
            };
        }

    }
}
