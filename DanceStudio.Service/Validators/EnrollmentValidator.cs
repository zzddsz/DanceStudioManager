using DanceStudio.Domain.Entities;
using FluentValidation;

namespace DanceStudio.Service.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>
    {
        public EnrollmentValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0).WithMessage("Invalid Student.");

            RuleFor(x => x.DanceClassId)
                .GreaterThan(0).WithMessage("Invalid Class.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");
        }
    }
}