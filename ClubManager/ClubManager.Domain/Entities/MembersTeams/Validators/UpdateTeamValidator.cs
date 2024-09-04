using ClubManager.Domain.DTOs.MembersTeams;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class UpdateTeamValidator : AbstractValidator<UpdateTeamDTO>
    {
        public UpdateTeamValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.TeamCategoryId)
                .NotEmpty().WithMessage("TeamCategoryId cannot be null.")
                .NotNull().WithMessage("TeamCategoryId cannot be empty.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .NotNull().WithMessage("Name cannot be null.");
            RuleFor(x => x.Male)
                .NotEmpty().WithMessage("Male cannot be empty.")
                .NotNull().WithMessage("Male cannot be null.");
            RuleFor(x => x.Female)
                .NotEmpty().WithMessage("Female cannot be empty.")
                .NotNull().WithMessage("Female cannot be null.");
            RuleFor(x => x.ClubId)
                .NotEmpty().WithMessage("ClubId cannot be empty.")
                .NotNull().WithMessage("ClubId cannot be null.");
        }
    }
}
