using FluentValidation;
using Timesheets.Models.Request;

namespace Timesheets.Infrastructure.Validation
{
    public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceRequestValidator()
        {
            RuleFor(x => x.ContractId)
                .NotEmpty();

            RuleFor(x => x.DateStart)
                .LessThanOrEqualTo(x => x.DateEnd)
                .WithMessage(ValidationMessages.RequestDataStarError);

            RuleFor(x => x.DateEnd)
                .GreaterThanOrEqualTo(x => x.DateStart)
                .WithMessage(ValidationMessages.RequestDataEndError);
        }
    }
}
