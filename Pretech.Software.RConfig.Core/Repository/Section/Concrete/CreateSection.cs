using JsonFormatterPlus;
using Pretech.Software.RConfig.Core.DBContext.Tables;

namespace Pretech.Software.RConfig.Core.Repository.Section.Concrete
{
    public struct CreateSection
    {

        public static TBL_Sections Create(string name, string value, string projectId)
        {
            return new TBL_Sections()
            {
                Active = true,
                Name = name,
                Value = JsonFormatter.Format(value),
                Create = DateTime.Now.ToUniversalTime(),
                Id = Guid.NewGuid(),
                ProjectId = Guid.Parse(projectId)
            };
        }
    }
}
