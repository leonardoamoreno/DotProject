using DotProject.Domain.Commands.Project.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Domain.Commands.Task.Validations
{
    public class RegisterNewTaskCommandValidation : TaskValidation<RegisterNewTaskCommand>
    {
        public RegisterNewTaskCommandValidation() 
        { 
            ValidateTitle();
            ValidateProjectId();
        }
    
    }
}
