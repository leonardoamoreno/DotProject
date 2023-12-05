using DotProject.Domain.Commands.Task.Validations;

namespace DotProject.Domain.Commands.Task
{
    public class RemoveTaskCommand : TaskCommand
    {
        public RemoveTaskCommand(Guid id) 
        { 
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveTaskCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
