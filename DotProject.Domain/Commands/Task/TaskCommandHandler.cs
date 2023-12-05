using DotProject.Domain.Events.Task;
using DotProject.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace DotProject.Domain.Commands.Task
{
    public class TaskCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewTaskCommand, ValidationResult>,
        IRequestHandler<UpdateTaskCommand, ValidationResult>,
        IRequestHandler<RemoveTaskCommand, ValidationResult>
    {
        private readonly ITaskRepository _TaskRepository;

        public TaskCommandHandler(ITaskRepository TaskRepository)
        {
            _TaskRepository = TaskRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewTaskCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var Task = new Models.Task(Guid.NewGuid(), message.Title, message.Description, message.ExpirationDate, message.Status, message.ProjectId);

            Task.AddDomainEvent(new TaskRegisteredEvent(Task.Id, Task.Title, Task.Description, Task.ExpirationDate, Task.Status, Task.ProjectId));

            _TaskRepository.Add(Task);

            return await Commit(_TaskRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateTaskCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var Task = new Models.Task(message.Id, message.Title, message.Description, message.ExpirationDate, message.Status, message.ProjectId);

            Task.AddDomainEvent(new TaskUpdatedEvent(Task.Id, Task.Title, Task.Description, Task.ExpirationDate, Task.Status, Task.ProjectId));

            _TaskRepository.Update(Task);

            return await Commit(_TaskRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveTaskCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = await _TaskRepository.GetById(message.Id);

            if (customer is null)
            {
                AddError("A Tarefa não existe.");
                return ValidationResult;
            }

            customer.AddDomainEvent(new TaskRemovedEvent(message.Id));

            _TaskRepository.Remove(customer);

            return await Commit(_TaskRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _TaskRepository.Dispose();
        }
    }
}
