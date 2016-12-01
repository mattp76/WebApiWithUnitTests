using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Interfaces;

namespace WebApiWithUnitTests.Test
{
    public class MockJsonHelper : IJsonHelper
    {

        private Products _products;

        public MockJsonHelper()
        {

            var mockJsonString = "productitems: [{id:5,firstname:'Jennifer',lastname:'Parker',items:[{Value:'fishing',Age:'50'},{Value:'football',Age:'60'},{Value:'cricket',Age:'70'}]}}]";
            _products = JsonConvert.DeserializeObject<Products>(mockJsonString);

        }


        public Products GetSnapShot()
        {
            return _products;
        }
    }
}
