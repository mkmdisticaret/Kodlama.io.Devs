using FluentValidation;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(c => c.IpAddress).NotEmpty();
            RuleFor(c => c.UserForRegisterDto).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Email).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Email).EmailAddress();
            RuleFor(c => c.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Password).NotEmpty();
            RuleFor(c => c.UserForRegisterDto.Password.Length).GreaterThanOrEqualTo(6);
        }
    }
}
