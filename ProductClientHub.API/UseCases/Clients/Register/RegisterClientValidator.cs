using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(Client => Client.Name).NotEmpty().WithMessage("O campo nome não pode ser vazio.");
            RuleFor(Client => Client.Email).EmailAddress().WithMessage("O campo email não é válido.");
        }
    }
}
