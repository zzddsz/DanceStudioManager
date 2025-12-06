using DanceStudio.Service.DTOs;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class TeacherValidator : AbstractValidator<TeacherDTO>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome obrigatório");

            RuleFor(x => x.Speciality)
                .NotEmpty().WithMessage("Especialidade obrigatória");
        }
    }
}
