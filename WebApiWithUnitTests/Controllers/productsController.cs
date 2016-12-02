using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiWithUnitTests.Dto;
using WebApiWithUnitTests.Interfaces;

namespace WebApiWithUnitTests.Controllers
{

    [RoutePrefix("api/v1/products")]
    public class ProductsController : ApiController
    {

        protected readonly IJsonHelper _jsonHelper;

        public ProductsController(IJsonHelper jsonHelper)
        {
            _jsonHelper = jsonHelper;
        }

        // GET api/v1/products
        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Products products = _jsonHelper.GetById();
            if (products == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            HttpResponseMessage response = Request.CreateResponse<Products>(HttpStatusCode.OK, products);

            return response;
        }


        // GET api/v1/products/1
        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                string name = _jsonHelper.GetById(id);
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



        // GET api/v1/products/1/jsonlinq
        [Route("{id:int}/jsonlinq")]
        [HttpGet]
        public HttpResponseMessage GetJsonLinq(int id)
        {
            try
            {

                List<String> name = _jsonHelper.GetByIdUsingLinqJson(id);
                if (name == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                HttpResponseMessage response = Request.CreateResponse<List<String>>(HttpStatusCode.OK, name);

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


        // GET api/v1/products/1/async
        [Route("{id:int}/async")]
        [ResponseType(typeof(Products))]
        public async Task<IHttpActionResult> GetASync(int id)
        {

            Products products = await _jsonHelper.GetByIdASync();

           if (products == null)
           {
               return NotFound();
           }
           return Ok(products);
          
        }
    }
}
