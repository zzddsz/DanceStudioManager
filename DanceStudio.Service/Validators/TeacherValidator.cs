using DanceStudio.Domain.Entities;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Specialty)
                .NotEmpty().WithMessage("Specialty is required.");
        }
    }
}