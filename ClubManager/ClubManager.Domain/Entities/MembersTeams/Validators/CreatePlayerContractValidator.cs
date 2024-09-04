using ClubManager.Domain.DTOs.MembersTeams;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class CreatePlayerContractValidator : AbstractValidator<CreatePlayerContractDTO>
    {
        public CreatePlayerContractValidator()
        {
            RuleFor(x => x.PlayerId).NotNull().NotEmpty();
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate cannot be null.")
                .NotNull().WithMessage("StartDate cannot be empty.");
            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate cannot be empty.")
                .NotNull().WithMessage("EndDate cannot be null.");
        }
    }
}
