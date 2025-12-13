using DanceStudio.Domain.Entities;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class DanceClassValidator : AbstractValidator<DanceClass>
    {
        public DanceClassValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Class Name is required.");

            RuleFor(x => x.Teacher)
                .NotEmpty().WithMessage("Teacher name is required.");

            RuleFor(x => x.DayOfWeek)
                .NotEmpty().WithMessage("Day of Week is required.");

            RuleFor(x => x.Time)
                .NotNull().WithMessage("Time is required.");

            RuleFor(x => x.MaxStudents)
                .GreaterThan(0).WithMessage("Max Students must be greater than 0.");
        }
    }
}