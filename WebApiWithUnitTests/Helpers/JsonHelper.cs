using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Interfaces;

namespace WebApiWithUnitTests.Helpers
{
    public class JsonHelper : IJsonHelper
    {

        private Products _products;
        private String _productsStr;
        protected readonly IRepository _respository;

        public JsonHelper(IRepository respository) 
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

            JObject productsJson = JObject.Parse(_productsStr);
            List<String> values = new List<String>();

            string value = (string)productsJson["productitems"]["items"][0]["value"];
            // Json.NET 1.3 + New license + Now on CodePlex

            JArray items = (JArray)productsJson["productitems"]["items"][0];



            var productsJsonTitles =
              from p in productsJson["productitems"]["items"]
              select (string)p["value"];

            foreach (var t in productsJsonTitles)
            {
                values.Add(t.ToString());
            }


            return values;
        }


        //Async Example
        public async Task<Products> GetByIdASync()
        {
            return _products;
        }
    }
}