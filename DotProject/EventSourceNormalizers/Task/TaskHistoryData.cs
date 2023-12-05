namespace DotProject.EventSourceNormalizers.Task
{
    public class TaskHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Status { get; set; }
        public string Timestamp { get; set; }
        public string Who { get; set; }
    }
}
