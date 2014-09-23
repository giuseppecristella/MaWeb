
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
        public CategoryAssignedProduct[] GetProductsByCatId(string categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}
