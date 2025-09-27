using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;
using System.Linq;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(int productId)
        {
            var dbContext = new ProductClientHubDbContext();

            var product = dbContext.Products.FirstOrDefault(product => product.Id == productId);
            if (product is null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }

            dbContext.Products.Remove(product);

            dbContext.SaveChanges();
        }
    }
}
