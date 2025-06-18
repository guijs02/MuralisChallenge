using FluentValidation;
using Muralis.Domain.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Validators
{
    internal class ClienteValidator : AbstractValidator<Cliente>, IValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(s => s.Nome)
           .NotEmpty().WithMessage("Nome não deve ser vazio!")
           .NotNull().WithMessage("Nome é obrigatório");
           
            RuleFor(s => s.DataCadastro)
           .NotEmpty().WithMessage("DataCadastro não deve ser vazio!")
           .NotNull().WithMessage("DataCadastro é obrigatório");

            RuleFor(s => s.Contatos)
           .NotEmpty().WithMessage("Contatos não deve ser vazio!")
           .NotNull().WithMessage("Contatos é obrigatório");
           
        }
    }
}
