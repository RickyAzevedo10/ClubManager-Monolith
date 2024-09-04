using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Utils;
using FluentValidation;

namespace ClubManager.Domain.Entities.Identity.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail cannot be null.")
                .NotNull().WithMessage("E-mail cannot be empty.")
                .EmailAddress().WithMessage("E-mail must be valid.");
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .NotNull().WithMessage("Username cannot be null.");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("The password must not be empty.")
                .NotNull().WithMessage("The password must not be null.")
                .MinimumLength(8).WithMessage("The password must have at least 8 characters.")
                .Must(PasswordValidation.ContainsUpperCaseLetter).WithMessage("The password must have at least 1 uppercase letter.")
                .Must(PasswordValidation.ContainsDigit).WithMessage("The password must have at least 1 number.");
            RuleFor(user => user.RoleId)
                .NotEmpty().WithMessage("RoleId cannot be empty.")
                .NotNull().WithMessage("RoleId cannot be null.")
                .InclusiveBetween(1, 7).WithMessage("RoleId must be between 1 and 7.");
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
