using NetDevPack.Domain;

namespace DotProject.Domain.Models
{
    public class Task : Entity, IAggregateRoot
    {
        public Task(Guid id, string title, string description, DateTime expirationDate, int status, Guid projectId)
        { 
            Id = id; 
            Title = title; 
            Description = description;
            ExpirationDate = expirationDate; 
            Status = status;
            ProjectId = projectId;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Status { get; set; }
        public Guid ProjectId { get; set; } = Guid.Empty;
        public Project Project { get; set; } = null!;
        

    }
}
