using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWithUnitTests.Dto;

namespace WebApiWithUnitTests.Interfaces
{
    public interface IJsonHelper
    {
        Products GetSnapShot();
    }
}