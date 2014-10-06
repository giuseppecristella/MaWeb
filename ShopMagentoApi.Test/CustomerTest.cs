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
    private string _apiUrl;
    private string _apiUser;
    private string _apiPassword;
    private string _sessionId;

    [TestInitialize]
    public void TestInitialize()
    {
      _apiUrl = "http://www.zoom2cart.com/api/xmlrpc";
      _apiUser = "ws_user";
      _apiPassword = "123456";

      //HttpContext.Current = new HttpContext(
      //  new HttpRequest(null, "http://tempuri.org", null),
      //  new HttpResponse(null));
    }

    [TestMethod]
    public void Should_Create_A_Customer_In_Magento_Repository()
    {
      //var customer = CreateCustomer();
      //var repository = new RepositoryService(MagentoConnection.Instance, FakeCacheManager);


    }

    private Customer CreateCustomer()
    {
      return new Customer()
      {
        firstname = "Giuseppe",
        lastname = "Cristella",
        email = "giuseppe.cristella@libero.it",
        created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
      };
    }
  }
}
