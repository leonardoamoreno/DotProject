using MediatR;
using System.Threading.Tasks;

namespace DotProject.Domain.Events.Project
{
    public class ProjectEventHandler :
        INotificationHandler<ProjectRegisteredEvent>,
        INotificationHandler<ProjectUpdatedEvent>,
        INotificationHandler<ProjectRemovedEvent>
    {
        public System.Threading.Tasks.Task Handle(ProjectRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task Handle(ProjectUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task Handle(ProjectRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return System.Threading.Tasks.Task.CompletedTask;
        }

    }
}
