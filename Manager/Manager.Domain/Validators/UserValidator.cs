using FluentValidation;
using Manager.Domain.Entities;


namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entity cannot be empty.")
                .NotNull()
                .WithMessage("Entity cannot be null.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .NotNull()
                .WithMessage("Name cannot be null.")
                .MinimumLength(3)
                .WithMessage("The name must al least 3 characters.")
                .MaximumLength(100)
                .WithMessage("The name must have a maximum of 100 characters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty.")
                .NotNull()
                .WithMessage("Password cannot null.")
                .MinimumLength(6)
                .WithMessage("The password must al least 6 characters.")
                .MaximumLength(80)
                .WithMessage("The password must have a maximum of 80 characters.");



            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty.")
                .NotNull()
                .WithMessage("Email cannot be null.")
                .MinimumLength(6)
                .WithMessage("The email must al least 6 characters.")
                .MaximumLength(180)
                .WithMessage("The email must have a maximum of 100 characters.")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email entered is not valid.");
        } 

    }
}