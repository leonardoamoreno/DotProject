namespace DotProject.Domain.Commands.Task.Validations
{
    public class RegisterNewTaskCommandValidation : TaskValidation<RegisterNewTaskCommand>
    {
        public RegisterNewTaskCommandValidation() 
        { 
            ValidateTitle();
            ValidateProjectId();
            ValidatePriority();
        }
    
    }
}
