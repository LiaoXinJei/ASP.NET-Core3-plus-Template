using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyInjection.Services.Interface
{
    public interface ITestService
    {
        string GetTestString();
        IEnumerable<string> GetABC();
    }
}
