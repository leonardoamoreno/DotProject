namespace DotProject.Domain.Commands.Project.Validations
{
    public class RemoveProjectCommandValidation : ProjectValidation<RemoveProjectCommand>
    {
        public RemoveProjectCommandValidation() 
        {
            ValidateId();
        }
    }
}
