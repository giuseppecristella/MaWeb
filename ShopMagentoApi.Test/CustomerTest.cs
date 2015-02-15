using System;
using System.Globalization;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Connection;
using MagentoRepository.Repository;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Infrastructure.Cache;
using ICacheManager = Microsoft.Practices.EnterpriseLibrary.Caching.ICacheManager;

namespace ShopMagentoApi.Test
{
    [TestClass]
    public class CustomerTest
    {

        [TestInitialize]
        public void TestInitialize()
        {
            MagentoConnection.Instance.Url = "http://www.zoom2cart.com/api/xmlrpc";
            MagentoConnection.Instance.UserId = "ws_user";
            MagentoConnection.Instance.Password = "123456";
        }

        [TestMethod]
        public void Should_Create_A_Customer_In_Magento_Repository()
        {
            var customer = CreateCustomer();
            var repository = new RepositoryService(MagentoConnection.Instance, new FakeCacheManager());
            var result = repository.CreateCustomer(customer);

        }

        [TestMethod]
        public void Shoul_Get_A_Customer_By_Id()
        {
            var repository = new RepositoryService(MagentoConnection.Instance, new FakeCacheManager());
            var customer = repository.GetCustomerById(40);
            Assert.IsNotNull(customer);
        }

        private Customer CreateCustomer()
        {
            return new Customer()
            {
                firstname = "Test User FirstName",
                lastname = "Test User LastName",
                email = "giuseppe.cristella@fromtest.it",
                mode = "register",
                created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
        }
    }
}
