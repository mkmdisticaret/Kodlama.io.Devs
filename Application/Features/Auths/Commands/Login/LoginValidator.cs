using FluentValidation;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(c => c.IpAddress).NotEmpty();
            RuleFor(c => c.UserForLoginDto).NotEmpty();
            RuleFor(c => c.UserForLoginDto.Email).NotEmpty();
            RuleFor(c => c.UserForLoginDto.Email).EmailAddress();
            RuleFor(c => c.UserForLoginDto.Password).NotEmpty();
        }
    }
}
