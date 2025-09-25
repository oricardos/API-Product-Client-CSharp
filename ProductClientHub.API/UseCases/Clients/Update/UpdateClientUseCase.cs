using ProductClientHub.API.Infrastructure;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(int clientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

           var client = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
            if (client is null)
            {
                throw new NotFoundException("Cliente não encontrado.");
            }

            client.Name = request.Name;
            client.Email = request.Email;

            dbContext.Clients.Update(client);
            dbContext.SaveChanges();
        }

        private void Validate( RequestClientJson request)
        {
            var validator = new RequestClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
