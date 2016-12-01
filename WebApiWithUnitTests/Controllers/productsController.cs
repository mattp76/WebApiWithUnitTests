﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Interfaces;

namespace WebApiWithUnitTests.Controllers
{
    public class ProductsController : ApiController
    {

        protected readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                string name = _repository.GetById(id);
                if (string.IsNullOrEmpty(name))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                HttpResponseMessage response = Request.CreateResponse<String>(HttpStatusCode.OK, name);

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Products products = _repository.GetById();
            if (products == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            HttpResponseMessage response = Request.CreateResponse<Products>(HttpStatusCode.OK, products);

            return response;
        }
    }
}