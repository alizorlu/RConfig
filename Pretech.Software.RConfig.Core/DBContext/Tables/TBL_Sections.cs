namespace Pretech.Software.RConfig.Core.DBContext.Tables
{
    public class TBL_Sections
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid ProjectId { get; set; }
        public bool Active { get; set; }  
        public DateTime Create { get; set; }
    }
}
