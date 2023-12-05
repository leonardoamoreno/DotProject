namespace DotProject.Domain.Commands.Project.Validations
{
    public class UpdateProjectCommandaValidation : ProjectValidation<UpdateProjectCommand>
    {
        public UpdateProjectCommandaValidation() 
        {
            ValidateId();
            ValidateName();
        }
    }
}
