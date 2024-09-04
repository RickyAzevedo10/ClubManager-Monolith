using ClubManager.Domain.DTOs.Identity;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class CreateUserPermissionsValidator : AbstractValidator<CreateUserPermissionsDTO>
    {
        public CreateUserPermissionsValidator()
        {
            RuleFor(x => x.Consult)
                .NotEmpty().WithMessage("Consult cannot be null.")
                .NotNull().WithMessage("Consult cannot be empty.");
            RuleFor(user => user.Edit)
                .NotEmpty().WithMessage("Edit cannot be empty.")
                .NotNull().WithMessage("Edit cannot be null.");
            RuleFor(user => user.Delete)
                .NotEmpty().WithMessage("Delete cannot be empty.")
                .NotNull().WithMessage("Delete cannot be null.");
            RuleFor(user => user.Create)
                .NotEmpty().WithMessage("Create cannot be empty.")
                .NotNull().WithMessage("Create cannot be null.");
        }
    }
}
