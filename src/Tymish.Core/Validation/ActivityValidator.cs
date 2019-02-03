using FluentValidation;
using Tymish.Core.Entities;

namespace Tymish.Core.Validation
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(a => a.Hours).NotEmpty().InclusiveBetween(0,24);
        }
    }
}