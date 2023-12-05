using NetDevPack.Messaging;

namespace DotProject.Domain.Events.Task
{
    public class TaskRemovedEvent : Event
    {
        public TaskRemovedEvent(Guid id) 
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
