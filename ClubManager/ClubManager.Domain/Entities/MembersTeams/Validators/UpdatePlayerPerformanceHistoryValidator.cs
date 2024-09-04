using ClubManager.Domain.DTOs.MembersTeams;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class UpdatePlayerPerformanceHistoryValidator : AbstractValidator<UpdatePlayerPerformanceHistoryDTO>
    {
        public UpdatePlayerPerformanceHistoryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.PlayerId).NotNull().NotEmpty();
            RuleFor(x => x.ClubOpponent)
                .NotEmpty().WithMessage("ClubOpponent cannot be null.")
                .NotNull().WithMessage("ClubOpponent cannot be empty.");
            RuleFor(x => x.Season)
                .NotEmpty().WithMessage("Season cannot be empty.")
                .NotNull().WithMessage("Season cannot be null.");
        }
    }
}
