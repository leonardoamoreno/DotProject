using DotProject.Domain.Commands.Project.Validations;
using DotProject.Domain.Commands.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Domain.Commands.Task.Validations
{
    public class RemoveTaskCommandValidation : TaskValidation<RemoveTaskCommand>
    {
        public RemoveTaskCommandValidation()
        {
            ValidateId();
        }
    }
}
