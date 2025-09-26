using ProductClientHub.API.Entities;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Products.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(int clientId, RequestProductJson request)
        {
            var dbContext = new ProductClientHubDbContext();
            Validate(dbContext, clientId, request);

            var product = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId
            };

            dbContext.Products.Add(product);

            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        private void Validate(ProductClientHubDbContext dbContext, int clientId,  RequestProductJson request)
        {
            var clientExist = dbContext.Clients.Any(client => client.Id == clientId);

            if(!clientExist)
                throw new NotFoundException($"Cliente com id {clientId} não foi encontrado.");
            var validator = new RequestProductValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
