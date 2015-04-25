using System.Globalization;
using System.Threading;
using Cache;
using MagentoRepository.Connection;
using MagentoRepository.Repository;
using Shop.Infrastructure.Cache;
using Cart = MagentoBusinessDelegate.Cart;


/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected readonly IRepository _repository;
    protected readonly ICacheManager _cache;

    #region Ctor

    // Constructor chaining; 
    // centralizzo la creazione dell'istanza della classe repository e del singleton 
    public BasePage()
        : this(new RepositoryService(MagentoConnection.Instance, new Cache.ELCacheManager()))
    {

    }

    public BasePage(IRepository repository)
    {
        _repository = repository;
        // come gestire una singola istanza della classe cache manager?
        _cache = new AspnetCacheManager(); // uso questa istanza per gestire il carrello mentre uso la cache di EL per i metodi del repo; analizzare meglio

    }

    #endregion Ctor

    protected Cart Cart
    {
        get
        {
            return SessionFacade.Cart;
        }
        set
        {
            SessionFacade.Cart = value;
        }
    }
}