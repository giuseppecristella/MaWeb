using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Ez.Newsletter.MagentoApi;
using MagentoBusinessApi.Test;
using MagentoBusinessDelegate.Helpers;
using MagentoRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cart = MagentoBusinessDelegate.Cart;
using CookComputing.XmlRpc;

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
