using FluentValidation;
using ProductClientHub.API.Entities;
using ProductClientHub.Communication.Requests;
using System.Data;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator()
        {
            RuleFor(Product => Product.Name).NotEmpty().WithMessage("O campo nome não pode ser vazio.");
            RuleFor(Product => Product.Brand).NotEmpty().WithMessage("O campo marca não pode ser vazio.");
            RuleFor(Product => Product.Price).GreaterThan(0).WithMessage("O campo preço deve ser maior que zero."); 
        }
    }
}
