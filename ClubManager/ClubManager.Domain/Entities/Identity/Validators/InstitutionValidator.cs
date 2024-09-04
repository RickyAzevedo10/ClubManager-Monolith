using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be null.")
                .NotNull().WithMessage("Name cannot be empty.");
            RuleFor(user => user.Address)
                .NotEmpty().WithMessage("Address cannot be empty.")
                .NotNull().WithMessage("Address cannot be null.");
        }
    }
}
