using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Infrastructure;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(int id)
        {
            var dbContext = new ProductClientHubDbContext();
            var client = dbContext
                .Clients
                .Include(client => client.Products)
                .FirstOrDefault(client => client.Id == id);

            if (client is null)
            {
                throw new NotFoundException("Cliente não encontrado.");
            }

            return new ResponseClientJson
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Products = client.Products.Select(product => new ResponseShortProductJson
                {
                    Id = product.Id,
                    Name = product.Name,
                }).ToList(),
            };
        }
    }
}
