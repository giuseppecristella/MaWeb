using System.Web;
using MagentoBusinessDelegate;

/// <summary>
/// Summary description for SessionFacade
/// </summary>
public static class SessionFacade
{
    private static T Get<T>(string key)
    {
        var obj = HttpContext.Current.Session[key];
        return obj == null ? default(T) : (T)obj;
    }

    private static void Set<T>(string key, T value)
    {
        HttpContext.Current.Session[key] = value;
    }

    private static void Remove(string key)
    {
        HttpContext.Current.Session.Remove(key);
    }

    public static Cart Cart
    {
        get
        {
            return Get<Cart>("Cart") ?? new Cart();
        }
        set
        {
            if (value == null)
            {
                Remove("Cart");
            }
            else
            {
                Set("Cart", value);
            }
        }
    }
}