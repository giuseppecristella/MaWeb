using Ez.Newsletter.MagentoApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace ShopMagentoApi.Test
{

    /// <summary>
    /// Summary description for ELCacheApplicatoinBlockTest
    /// </summary>
    [TestClass]
    public class ELCacheApplicatoinBlockTest
    {
        private string _apiUrl;
        private string _apiUser;
        private string _apiPassword;
        private string _sessionId;

        public ELCacheApplicatoinBlockTest()
        {
            _apiUrl = "http://www.zoom2cart.com/api/xmlrpc";
            _apiUser = "ws_user";
            _apiPassword = "123456";
            _sessionId = Ez.Newsletter.MagentoApi.Connection.Login(_apiUrl, _apiUser, _apiPassword);
            Assert.IsNotNull(_sessionId);

            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddProductToELCacheManager()
        {
            ICacheManager cacheManager = CacheFactory.GetCacheManager();
            var assignedProducts = Category.AssignedProducts(_apiUrl, _sessionId, new object[] { "47" });

            cacheManager.Add("test", assignedProducts);
            Assert.IsNotNull(assignedProducts, "Nessun prodoto trovato");
        }
    }
}
