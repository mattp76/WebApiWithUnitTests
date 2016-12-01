using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Interfaces;

namespace WebApiWithUnitTests.Helpers
{
    public class JsonHelper : IJsonHelper
    {
        public Products GetSnapShot()
        {
            string fileName = "test.json";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName);

            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    Products products = JsonConvert.DeserializeObject<Products>(json);
                    return products;
                }

            }
            catch(Exception ex)
            {

                return null;
            }
        }

    }
}