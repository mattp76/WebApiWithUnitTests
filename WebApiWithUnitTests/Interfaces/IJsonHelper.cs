using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApiWithUnitTests.Dto;

namespace WebApiWithUnitTests.Interfaces
{
    public interface IJsonHelper
    {
        Products GetById();
        String GetById(int id);
        Task<Products> GetByIdASync();
        List<String> GetByIdUsingLinqJson(int id);
    }
}