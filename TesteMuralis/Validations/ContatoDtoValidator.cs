using FluentValidation;
using Muralis.Application.Dtos;

namespace TesteMuralis.WebApi.Validations
{

    namespace TesteMuralis.WebApi.Validations
    {
        public class ContatoDtoValidator : AbstractValidator<ContatoDto>
        {
            public ContatoDtoValidator()
            {
                RuleFor(x => x.Tipo)
                    .NotEmpty().WithMessage("O tipo do contato é obrigatório.");

                RuleFor(x => x.Texto)
                    .NotEmpty().WithMessage("O texto do contato é obrigatório.");
            }
        }
    }
}
