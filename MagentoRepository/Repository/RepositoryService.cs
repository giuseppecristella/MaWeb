using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoComunication;


/// <summary>
/// Summary description for Repository
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
    assignedProducts = Category.AssignedProducts(_connection.url, _connection.GetSessionId(_cacheManager), new object[] { categoryId });
    return assignedProducts;
  }

}


