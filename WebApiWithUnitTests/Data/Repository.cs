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

namespace WebApiWithUnitTests.Data
{
    public class Repository : IRepository
    {

        private Products _products;
        protected readonly IJsonHelper _jsonHelper;

        public Repository(IJsonHelper jsonHelper) 
        {
            _jsonHelper = jsonHelper;
            _products = _jsonHelper.GetSnapShot();
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