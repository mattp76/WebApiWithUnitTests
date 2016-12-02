using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiWithUnitTests.Controllers;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Moq;
using WebApiWithUnitTests.Interfaces;
using System.Collections.Generic;
using WebApiWithUnitTests.Dto;
using Newtonsoft.Json;
using WebApiWithUnitTests.Helpers;
using WebApiWithUnitTests.Data;

namespace WebApiWithUnitTests.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Products _products;
        private String _productsStr;

        [TestInitialize]
        public void Setup()
        {
            //Used for the MOQ testing
            _productsStr = "{productitems: [{id:2,firstname:\"Leonardo\",lastname:\"Parker\", items: [{Value:\"fishing\", Age:\"50\"}]}]}";
            _products = JsonConvert.DeserializeObject<Products>(_productsStr);
        }


        //TEST USING CUSTOM MOCKS
        [TestMethod]
        public void GetReturnsAllProducts()
        {
            MockRepository mockRespository = new MockRepository();
            MockJsonHelper mockJsonHelper = new MockJsonHelper(mockRespository);

            var controller = new ProductsController(mockJsonHelper);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = controller.Get(2);


            String firstname;
            Assert.IsTrue(response.TryGetContentValue<String>(out firstname));
            Assert.AreEqual("Leonardo", firstname);

        }


        //TEST USING MOQ FRAMEWORK - mocking repository and jsonHelper
        [TestMethod]
        public void GetReturnsAllProducts_usingMoq()
        {

            //Mock<IRepository> moqRepository = new Mock<IRepository>();
            //moqRepository.Setup(x => x.GetSnapShot()).Returns(_products);
            //moqRepository.Setup(x => x.GetSnapShotString()).Returns(_productsStr);

            Mock<IJsonHelper> moqJsonHelper = new Mock<IJsonHelper>();
            moqJsonHelper.Setup(x => x.GetById(2)).Returns(_products.ProductItems[0].FirstName);

            var controller = new ProductsController(moqJsonHelper.Object);
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            var response = controller.Get(2);


            String firstname;
            Assert.IsTrue(response.TryGetContentValue<String>(out firstname));
            Assert.AreEqual("Leonardo", firstname);

        }




    }
}
