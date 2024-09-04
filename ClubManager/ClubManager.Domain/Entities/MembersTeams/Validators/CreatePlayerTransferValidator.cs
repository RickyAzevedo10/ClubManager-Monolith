using ClubManager.Domain.DTOs.MembersTeams;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class CreatePlayerTransferValidator : AbstractValidator<CreatePlayerTransferDTO>
    {
        public CreatePlayerTransferValidator()
        {
            RuleFor(x => x.PlayerId).NotNull().NotEmpty();
            RuleFor(x => x.FromClub)
                .NotEmpty().WithMessage("FromClub cannot be null.")
                .NotNull().WithMessage("FromClub cannot be empty.");
            RuleFor(x => x.ToClub)
                .NotEmpty().WithMessage("ToClub cannot be empty.")
                .NotNull().WithMessage("ToClub cannot be null.");
        }
    }
}
