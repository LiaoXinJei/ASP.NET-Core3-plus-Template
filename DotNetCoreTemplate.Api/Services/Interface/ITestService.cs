using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTemplate.Api.ApiServices.Interface
{
    public interface ITestService
    {
        string GetTestString();
        IEnumerable<string> GetABC();
    }
}
