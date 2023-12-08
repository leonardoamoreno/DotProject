using DotProject.Domain.Models;
using NetDevPack.Messaging;

namespace DotProject.Domain.Events.Task
{
    public class TaskUpdatedEvent : Event
    {
        public TaskUpdatedEvent(Guid id, string title, string description, DateTime expirationDate, Priority priority, int status, Guid projectId) 
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            ExpirationDate = expirationDate;
            ProjectId = projectId;
            AggregateId = id;
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Priority Priority { get; set; }
        public int Status { get; set; }
        public Guid ProjectId { get; set; } = Guid.Empty;
    }
}
