using DotProject.Domain.Events.Project;
using DotProject.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace DotProject.Domain.Commands.Project
{
    public class ProjectCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProjectCommand, ValidationResult>,
        IRequestHandler<UpdateProjectCommand, ValidationResult>,
        IRequestHandler<RemoveProjectCommand, ValidationResult>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = new Models.Project(Guid.NewGuid(), message.Name, message.UserId);

            project.AddDomainEvent(new ProjectRegisteredEvent(project.Id, project.Name, project.UserId));

            _projectRepository.Add(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = new Models.Project(message.Id, message.Name, message.UserId);

            project.AddDomainEvent(new ProjectUpdatedEvent(project.Id, project.Name, project.UserId));

            _projectRepository.Update(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var project = await _projectRepository.GetById(message.Id);

            if (project is null)
            {
                AddError("O Projeto não existe.");
                return ValidationResult;
            }

            if (project.Tasks.Any(x=> x.Status.Equals(0))) 
            {
                AddError("Não é possível remover esse projeto, existem tarefas pendentes.");
                return ValidationResult;
            }

            project.AddDomainEvent(new ProjectRemovedEvent(message.Id));

            _projectRepository.Remove(project);

            return await Commit(_projectRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _projectRepository.Dispose();
        }
    }
}
