using DotProject.Domain.Models;
using NetDevPack.Messaging;

namespace DotProject.Domain.Events.Project
{
    public class ProjectUpdatedEvent : Event
    {
        public ProjectUpdatedEvent(Guid id, string name, Guid userId) 
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public User User { get; set; }
    }
}
