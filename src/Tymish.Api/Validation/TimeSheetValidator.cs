using FluentValidation;
using Tymish.Core.Entities;

namespace Tymish.Api.Validation
{
    public class TimeSheetValidator : AbstractValidator<TimeSheet>
    {
        public TimeSheetValidator()
        {
            RuleFor(t => t.Submitted)
                .GreaterThan(t => t.Issued);

            RuleFor(t => t.Approved)
                .GreaterThan(t => t.Submitted);
        }
    }
}