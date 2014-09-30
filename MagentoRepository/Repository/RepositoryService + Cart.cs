using System;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;

namespace MagentoRepository.Repository
{

  public partial class RepositoryService
  {
    public int CreateCart()
    {
      try
      {
        return Cart.create(_connection.Url, _connection.SessionId);
      }
      catch (Exception)
      {
        return 0;
      }
    }
  }
}
