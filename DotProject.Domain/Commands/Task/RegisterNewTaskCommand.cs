using DotProject.Domain.Commands.Task.Validations;

namespace DotProject.Domain.Commands.Task
{
    public class RegisterNewTaskCommand : TaskCommand
    {
        public RegisterNewTaskCommand(string title, string description, DateTime expirationDate, int status, Guid projectId) 
        { 
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;
            Status = status;
            ProjectId = projectId;                       
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewTaskCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
