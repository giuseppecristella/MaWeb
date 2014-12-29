using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MagentoBusinessDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopMagentoApi.Test
{
    /// <summary>
    /// Summary description for UsefulFunctionsTest
    /// </summary>
    [TestClass]
    public class UsefulFunctionsTest
    {
        public UsefulFunctionsTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
        public void Should_Create_Layout_Template_With_Builder()
        {
            // percorso del template html
            var filePath = @"C:\Progetti\MA\MA.Web\public\templates\template_nl.html";
            var layoutBuilder = new LayoutBuilder(filePath);
            var templateHtml = layoutBuilder.AddName("Nome Cognome")
              .AddInvoiceHolder("A C").AddInvoiceAddress("via address")
              .AddShipmentHolder("Giuseppe Cristella").AddShipmentAddress("Via roma, 3")
              .AddTotalShipment("150").AddTotalOrder("1").Build();
        }

        [TestMethod]
        public void Should_Parse_Uri_String()
        {
            var uri = new Uri("http://www.materaarredamenti.it/public/catalog/product/cache/0/image/9df78eab33525d08d6e5fb8d27136e95/s/c/scollati_2_3.jpg");
            var segments = uri.Segments;
            string result = string.Empty;
            foreach (var segment in segments)
            {
                Guid guidValue;
                if (Guid.TryParse(segment.Remove(segment.Length - 1, 1), out guidValue))
                {
                    result = guidValue.ToString();
                }
            }          
            Assert.IsTrue(!string.IsNullOrEmpty(result));
            // Assert.IsTrue(result.Equals("9df78eab33525d08d6e5fb8d27136e95"));
            var imageName = segments.LastOrDefault();
            Assert.AreEqual(imageName, "scollati_2_3.jpg");
        }
    }
}
