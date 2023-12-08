using FluentValidation;

namespace DotProject.Domain.Commands.Task.Validations
{
    public abstract class TaskValidation<T> : AbstractValidator<T> where T: TaskCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Por favor informe o titulo da tarefa");
        }

        protected void ValidateProjectId()
        {
            RuleFor(c => c.ProjectId)
                .NotEmpty().WithMessage("Informe o Id do projeto para adicionar uma tarefa");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePriority() 
        {
            RuleFor(c => c.Priority)
                .NotNull()
                .WithMessage("O campo Prioridade é Obrigatória");
        }
        
    }
}
