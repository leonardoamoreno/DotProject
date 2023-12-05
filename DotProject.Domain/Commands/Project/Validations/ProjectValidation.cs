using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Domain.Commands.Project.Validations
{
    public abstract class ProjectValidation<T> : AbstractValidator<T> where T : ProjectCommand
    {
        protected void ValidateName() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor infome o nome do projeto");
        }

        protected void ValidateUserId()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("Informe o Id do usuário para adicionar um projeto");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

    }
}
