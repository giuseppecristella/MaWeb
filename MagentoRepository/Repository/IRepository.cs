using System.Collections.Generic;
using Ez.Newsletter.MagentoApi;
using MagentoComunication.Enum;

namespace MagentoRepository.Repository
{
    public interface IRepository
    {
        #region Product

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        List<CategoryAssignedProduct> GetProductsByCategoryId(string categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Product GetFilteredProducts(Filter filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetProductInfo(string productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<Inventory> GetInventories(string productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<ProductImage> GetProductImages(string productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<ProductLink> GetLinkedProducts(string productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        int GetStocksForProduct(string productId);

        #endregion

        #region Category

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCategoryInfo(string categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        object GetCategoryLevel(string categoryId);

        #endregion Category

        #region Cart

        int CreateCart();

        bool AssociateCustomerToCart(int cartId, Customer customer);

        bool AddCustomerAddressesToCart(int cartId, List<CustomerAddress> customerAddresses);

        bool AddProductToCart(int cartId, Product product);
        List<PaymentMethod> GetPaymentMethods(int cartId);
        // usare enum per shipping method
        bool AddShippingMethodToCart(int cartId, string shippingMethod);

        List<ShippingMethod> GetShippingMethods(int cartId);

        bool AddPaymentMethodsToCart(int cartId, PaymentMethod paymentMethod);

        #endregion

        #region Customers

        string CreateCustomer(Customer customer);

        Customer GetCustomerById(int customerId);

        string CreateCustomerAddress(int customerId, CustomerAddress customerAddress);

        List<CustomerAddress> GetCustomerAddresses(int customerId);

        bool UpdateCustomerAddress(CustomerAddress billingAddress, int addressBillingId);

        #endregion

        #region Orders

        OrderInfo GetOrderInfos(int orderNumber);

        bool SetOrderStatus(int orderNumber, OrderStatusType status);

        List<Order> GetOrders(Filter filter);

        int CreateOrder(int cartId);

        #endregion

    }
}
