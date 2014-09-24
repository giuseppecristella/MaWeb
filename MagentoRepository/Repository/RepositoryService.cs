using Ez.Newsletter.MagentoApi;
using MagentoComunication.Cache;
using MagentoRepository.Connection;


/// <summary>
/// Classe Repository di accesso al dominio di Magento
/// attraverso le API esposte dal suo web service 
/// NOTE: 
/// 1) l'object model Magento dovrebbe essere rimappato su oggetti semplificati del nostro dominio
/// a tal proposito potrebbe essere usato EF come ulteriore layer;
/// 2) tutti i metodi dovrebbero cachare i risultati, da implementare considerando un adeguato pattern di caching
/// </summary>
public class RepositoryService : IRepository
{

  private IMagentoConnection _connection;
  private ICacheManager _cacheManager;

  // Constructor injection
  public RepositoryService(IMagentoConnection connection, ICacheManager cacheMAnager)
  {
    _connection = connection;
    _cacheManager = cacheMAnager;
  }

  public CategoryAssignedProduct[] GetProductsByCatId(string categoryId)
  {
    CategoryAssignedProduct[] assignedProducts = null;
    assignedProducts = Category.AssignedProducts(_connection.url, _connection.SessionId, new object[] { categoryId });
    return assignedProducts;
  }

}


