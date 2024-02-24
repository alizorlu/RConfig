namespace Pretech.Software.RConfig.UI.Response
{
    public class ResponseProjects
    {
        public List<ProjectLine> data { get; set; }
        public bool isSuccess { get; set; }
        public object message { get; set; }

    }
    public class ResponseProject
    {
        public ProjectLine data { get; set; }
        public bool isSuccess { get; set; }
        public object message { get; set; }

    }
    public class ProjectLine
    {
        public string id { get; set; }
        public string name { get; set; }
        public string secret { get; set; }
        public string key { get; set; }
        public string application { get; set; }
        public bool active { get; set; }
        public DateTime create { get; set; }
        public DateTime update { get; set; }
        public string restrictedList { get; set; }
    }
}
