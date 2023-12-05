using NetDevPack.Messaging;

namespace DotProject.Domain.Events.Project
{
    public class ProjectRemovedEvent : Event
    {
        public ProjectRemovedEvent(Guid id) 
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
