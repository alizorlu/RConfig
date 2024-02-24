namespace Pretech.Software.RConfig.Core.DBContext.Tables
{
    public class TBL_Projects
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string Key { get; set; }
        public string Application { get; set; }
        public bool Active { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        public string RestrictedList { get; set; } = "*";
    }
}
