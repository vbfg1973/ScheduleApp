using FluentValidation;

namespace Scheduler.Model.ViewModels.Validations
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(user => user.Profession).NotEmpty().WithMessage("Profession cannot be empty");
            RuleFor(user => user.Avatar).NotEmpty().WithMessage("Avatar cannot be empty");
        }
    }
}