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

        public MockRepository()
        {

            //String expected = "{friends:[{id:123,name:\"Corby Page\"},{id:456,name:\"Carter Page\"}]}";
            String mockJsonString = "{productitems: [{id:2,firstname:\"Leonardo\",lastname:\"Parker\", items: [{Value:\"fishing\", Age:\"50\"}]}]}";
            _products = JsonConvert.DeserializeObject<Products>(mockJsonString);

        }


        public string GetById(int id)
        {

            var res = from r in _products.ProductItems
                      where r.id == id
                      select r.FirstName;


            return res.FirstOrDefault();
        }


        public Products GetById()
        {
            return _products;
        }
    }
}
