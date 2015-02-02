using MagentoComunication.Cache;
using MagentoRepository.Helpers;
using MagentoRepository.Repository;
using Cart = MagentoBusinessDelegate.Cart;


/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
  protected readonly IRepository _repository;
  protected readonly ICacheManager _cache;
  private static readonly string _cacheKey = ConfigurationHelper.CacheKeyNames[CacheKey.Cart];

  #region Ctor

  // Constructor chaining; 
  // centralizzo la creazione dell'istanza della classe repository e del singleton 
  public BasePage()
    : this(new RepositoryService(MagentoConnection.Instance, new AspnetCacheManager()))
  {

  }

  public BasePage(IRepository repository)
  {
    _repository = repository;
    // come gestire una singola istanza della classe cache manager?
    _cache = new AspnetCacheManager();
  }

  #endregion Ctor

  protected Cart Cart
  {
    get
    {
      return (_cacheKey != null && _cache.Contains(_cacheKey)) ? _cache.Get<Cart>(_cacheKey) : null;
    }
    set
    {
      _cache.Remove(_cacheKey);
      _cache.Add(_cacheKey, value);
    }
  }
}