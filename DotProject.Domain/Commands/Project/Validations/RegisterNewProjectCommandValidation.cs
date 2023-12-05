namespace DotProject.Domain.Commands.Project.Validations
{
    public class RegisterNewProjectCommandValidation : ProjectValidation<RegisterNewProjectCommand>
    {
        public RegisterNewProjectCommandValidation() 
        {
            ValidateName();
            ValidateUserId();
        }
    }
}
