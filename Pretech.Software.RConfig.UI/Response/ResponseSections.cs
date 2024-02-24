namespace Pretech.Software.RConfig.UI.Response
{
    public class ResponseSections
    {
        public List<SectionsLine> data { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
    public class SectionsLine
    {
        public string id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string projectId { get; set; }
        public bool active { get; set; }
        public DateTime create { get; set; }
    }
}
