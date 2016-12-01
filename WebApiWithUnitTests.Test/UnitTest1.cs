using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiWithUnitTests.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace WebApiWithUnitTests.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetReturnsAllProducts()
        {

            MockRepository repository = new MockRepository();
            
            var controller = new ProductsController(repository);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = controller.Get(2);


            String firstname;
            Assert.IsTrue(response.TryGetContentValue<String>(out firstname));
            Assert.AreEqual("Leonardo", firstname);

        }


        [TestMethod]
        public void GetReturnsAllProductsOnId()
        {



        }

    }
}
