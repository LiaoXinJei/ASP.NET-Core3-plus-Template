﻿using PropertyInjection.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyInjection.Services
{
    public class TestService : ITestService
    {
        public string GetTestString()
        {
            return "This is a test string.";
        }

        public IEnumerable<string> GetABC()
        {
            return new List<string>() { "A", "B", "C" };
        }
    }
}
