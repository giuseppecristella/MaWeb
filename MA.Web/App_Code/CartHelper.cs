using Ez.Newsletter.MagentoApi;
public static class CartHelper
{
    public static void AddProductToCartAndUpdateCache(Product product)
    {
        var cart = SessionFacade.Cart;
        cart.AddProductAndUpdateTotal(product);
        SessionFacade.Cart = cart;
    }

    public static void ClearCart()
    {
        SessionFacade.Cart = null;
    }
}

