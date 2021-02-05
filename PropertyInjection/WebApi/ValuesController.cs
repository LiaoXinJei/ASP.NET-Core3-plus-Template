using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyInjection.Models;
using PropertyInjection.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyInjection.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ITestService TestService { get; set; }

        private readonly ITestService _t;
        public ValuesController(ITestService t)
        {
            _t = t;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var testString = TestService.GetTestString();
            return Ok(testString);
        }

        [HttpPost]
        public IActionResult Post(ModelA model)
        {
            return Ok();
        }
    }
}
