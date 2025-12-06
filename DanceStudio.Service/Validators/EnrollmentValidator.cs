using DanceStudio.Service.DTOs;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class EnrollmentValidator : AbstractValidator<EnrollmentDTO>
    {
        public EnrollmentValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("Aluno inválido");

            RuleFor(x => x.DanceClassId)
                .GreaterThan(0).WithMessage("Aula inválida");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Data da matrícula obrigatória");
        }
    }
}
