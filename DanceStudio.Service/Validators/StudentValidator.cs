using DanceStudio.Service.DTOs;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class StudentValidator : AbstractValidator<StudentDTO>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome obrigatório")
                .MaximumLength(100).WithMessage("Nome muito grande");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Idade deve ser maior que 0")
                .LessThan(120).WithMessage("Idade inválida");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Nível obrigatório");
        }
    }
}
