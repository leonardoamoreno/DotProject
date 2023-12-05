using MediatR;

namespace DotProject.Domain.Events.Task
{
    public class TaskEventHandler :
        INotificationHandler<TaskRegisteredEvent>,
        INotificationHandler<TaskUpdatedEvent>,
        INotificationHandler<TaskRemovedEvent>
    {
        public System.Threading.Tasks.Task Handle(TaskRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task Handle(TaskUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task Handle(TaskRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
