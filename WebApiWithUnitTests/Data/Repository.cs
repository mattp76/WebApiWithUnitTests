using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWithUnitTests.Interfaces;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Helpers;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace WebApiWithUnitTests.Data
{
    public class Repository : IRepository
    {

        private const string fileName = "test.json";
        private static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName);


        public Products GetSnapShot()
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    Products products = JsonConvert.DeserializeObject<Products>(json);
                    return products;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public String GetSnapShotString()
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    return json;
                }

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}