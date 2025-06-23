using FluentValidation;
using Muralis.Application.Dtos;

namespace TesteMuralis.WebApi
{

    public class AlterarClienteDtoValidator : AbstractValidator<AlterarClienteDto>
    {
        public AlterarClienteDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");
                
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .MinimumLength(8).WithMessage("O CEP deve ter no mínimo 8 caracteres.")
                .MaximumLength(9).WithMessage("O CEP deve ter no máximo 9 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O número é obrigatório.");

        }
    }
}
