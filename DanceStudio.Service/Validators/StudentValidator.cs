using DanceStudio.Domain.Entities;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name is too long (max 100 chars).");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0.")
                .LessThan(120).WithMessage("Invalid age.");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Level is required.");
        }
    }
}