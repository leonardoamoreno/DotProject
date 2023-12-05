using DotProject.Domain.Models;
using NetDevPack.Messaging;

namespace DotProject.Domain.Events.Project
{
    public class ProjectRegisteredEvent : Event
    {
        public ProjectRegisteredEvent(Guid id, string name, Guid userId) 
        {
            Id = id;
            Name = name;
            UserId = userId;
            AggregateId = id;
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public User User { get; set; }
    }
}
