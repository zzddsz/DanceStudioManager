using DanceStudioManager.DTOs;
using FluentValidation;

namespace DanceStudioManager.Validators
{
    public class DanceClassValidator : AbstractValidator<DanceClassDTO>
    {
        public DanceClassValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome obrigatório");
            RuleFor(x => x.Professor).NotEmpty().WithMessage("Professor obrigatório");
            RuleFor(x => x.DiaDaSemana).NotEmpty();
            RuleFor(x => x.Horario).NotNull();
            RuleFor(x => x.NumeroVagas).GreaterThan(0).WithMessage("Vagas deve ser > 0");
        }
    }
}
