using DotProject.Domain.Commands.Project.Validations;

namespace DotProject.Domain.Commands.Project
{
    public class RegisterNewProjectCommand : ProjectCommand
    {
        public RegisterNewProjectCommand(string name, Guid userId) 
        { 
            Name = name;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProjectCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
