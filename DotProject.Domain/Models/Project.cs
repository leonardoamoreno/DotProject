using NetDevPack.Domain;

namespace DotProject.Domain.Models
{
    public class Project : Entity, IAggregateRoot
    {
        public Project(Guid id, string name, Guid userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public User User { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
