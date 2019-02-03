using FluentValidation;
using Tymish.Core.Entities;

namespace Tymish.Core.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().Length(0,25);
            RuleFor(e => e.LastName).NotEmpty().Length(0,25);
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.HourlyPay).NotEmpty().InclusiveBetween(0,100);
        }
    }
}