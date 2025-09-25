using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(Client => Client.Name).NotEmpty().WithMessage("O campo nome não pode ser vazio.");
            RuleFor(Client => Client.Email).EmailAddress().WithMessage("O campo email não é válido.");
        }
    }
}
