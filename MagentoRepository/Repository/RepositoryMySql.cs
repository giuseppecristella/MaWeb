
using Ez.Newsletter.MagentoApi;

namespace MagentoRepository.Repository
{
    /// <summary>
    /// Implementa la classe repository di accesso al modello
    /// di dominio di Magento attraverso l'interrogazione
    /// diretta del database mysql
    /// </summary>
    public class RepositoryMySql: IRepository
    {
        public CategoryAssignedProduct[] GetProductsByCategoryId(string categoryId)
        {
            throw new System.NotImplementedException();
        }

      public Product GetProductById(string productId)
      {
        throw new System.NotImplementedException();
      }
    }
}
