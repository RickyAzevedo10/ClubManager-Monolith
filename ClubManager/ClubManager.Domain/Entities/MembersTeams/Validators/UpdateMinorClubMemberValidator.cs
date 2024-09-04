using ClubManager.Domain.DTOs.MembersTeams;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class UpdateMinorClubMemberValidator : AbstractValidator<UpdateMinorClubMemberDTO>
    {
        public UpdateMinorClubMemberValidator()
        {
            RuleFor(x => x.MinorClubMemberId).NotEmpty();
            RuleFor(x => x.MemberId).NotEmpty();
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Name cannot be null.")
                .NotNull().WithMessage("Name cannot be empty.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty.")
                .NotNull().WithMessage("Address cannot be null.");
        }
    }
}
