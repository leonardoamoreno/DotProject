using DotProject.Domain.Commands.Project.Validations;

namespace DotProject.Domain.Commands.Project
{
    public class UpdateProjectCommand : ProjectCommand
    {
        public UpdateProjectCommand(Guid id, string name) 
        { 
            Id = id;
            Name = name;            
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProjectCommandaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
