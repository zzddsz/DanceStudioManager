using DanceStudio.Service.DTOs;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class DanceClassValidator : AbstractValidator<DanceClassDTO>
    {
        public DanceClassValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Teacher)
                .NotEmpty().WithMessage("Teacher is required");

            RuleFor(x => x.DayOfWeek)
                .NotEmpty().WithMessage("Day is required");

            RuleFor(x => x.Time)
                .NotNull().WithMessage("Time is required");

            RuleFor(x => x.MaxStudents)
                .GreaterThan(0).WithMessage("Max Students must be > 0");
        }
    }
}