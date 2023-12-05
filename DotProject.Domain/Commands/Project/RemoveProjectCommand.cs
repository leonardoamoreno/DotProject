using DotProject.Domain.Commands.Project.Validations;

namespace DotProject.Domain.Commands.Project
{
    public class RemoveProjectCommand : ProjectCommand
    {
        public RemoveProjectCommand(Guid id) 
        { 
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
