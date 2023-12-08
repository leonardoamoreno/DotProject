using DotProject.Domain.Commands.Task.Validations;
using DotProject.Domain.Models;

namespace DotProject.Domain.Commands.Task
{
    public class RegisterNewTaskCommand : TaskCommand
    {
        public RegisterNewTaskCommand(string title, string description, DateTime expirationDate, Priority priority, int status, Guid projectId) 
        { 
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;     
            Priority = priority;
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
