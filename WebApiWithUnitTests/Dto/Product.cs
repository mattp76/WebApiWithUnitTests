using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithUnitTests.Dto
{
    public class Products
    {
        [JsonProperty(PropertyName = "productitems")]
        public List<Product> ProductItems { get; set; }
    }


    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<ProductItems> Items { get; set; }
    }


    public class ProductItems
    {
        public string Value { get; set; }
        public string Age { get; set; }
    }
}