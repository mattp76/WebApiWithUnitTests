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
        private String _productsStr;
        protected readonly IRepository _respository;

        public MockJsonHelper(IRepository respository) 
        {
            _products = _respository.GetSnapShot();
            _productsStr = _respository.GetSnapShotString();
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


        public List<String> GetByIdUsingLinqJson(int id)
        {
            List<String> values = new List<String>();
            return values;
        }


        //Async Example
        public async Task<Products> GetByIdASync()
        {
            return _products;
        }
    }
}
