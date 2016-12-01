using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiWithUnitTests.Dto;

namespace WebApiWithUnitTests.Interfaces
{
    public interface IRepository
    {
        Products GetById();
        string GetById(int id);
    }
}
