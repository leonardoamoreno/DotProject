using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Domain.Commands.Task.Validations
{
    public class UpdateTaskCommandValidation : TaskValidation<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidation() 
        {
            ValidateId();
            ValidateTitle();
            ValidateProjectId();
        }
    }
}
