using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(int clientId)
        {
            var dbContext = new ProductClientHubDbContext();

            var client = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
            if (client is null)
            {
                throw new NotFoundException("Cliente não encontrado.");
            }

            dbContext.Clients.Remove(client);

            dbContext.SaveChanges();
        }
    }
}
