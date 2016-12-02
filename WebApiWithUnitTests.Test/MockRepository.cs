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
    public class MockRepository : IRepository
    {

        private Products _products;
        private String _productsStr;

        public MockRepository()
        {
            _productsStr = "{productitems: [{id:2,firstname:\"Leonardo\",lastname:\"Parker\", items: [{Value:\"fishing\", Age:\"50\"}]}]}";
            _products = JsonConvert.DeserializeObject<Products>(_productsStr);
        }

        public Products GetSnapShot()
        {
            return _products;
        }

        public String GetSnapShotString()
        {
            return _productsStr;
        }
    }
}
