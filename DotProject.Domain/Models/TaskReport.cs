namespace DotProject.Domain.Models
{
    public class TaskReport
    {
        public string UserName { get; set; }
        public decimal PercentageComplete { get; set; }
        public int Done { get; set; }
        public int NotCompleted { get; set; }
        public int Total { get; set; }
    }
}
