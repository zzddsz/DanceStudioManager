using DanceStudio.Service.DTOs;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class DanceClassValidator : AbstractValidator<DanceClassDTO>
    {
        public DanceClassValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome obrigatório");
            RuleFor(x => x.Professor).NotEmpty().WithMessage("Professor obrigatório");
            RuleFor(x => x.DiaDaSemana).NotEmpty().WithMessage("Dia obrigatório");
            RuleFor(x => x.Horario).NotNull().WithMessage("Horário obrigatório");
            RuleFor(x => x.NumeroVagas).GreaterThan(0).WithMessage("Vagas deve ser > 0");
        }
    }
}
