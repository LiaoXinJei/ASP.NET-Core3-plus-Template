using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreTemplate.Api.ApiModels;
using DotNetCoreTemplate.Api.ApiServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Interface;

namespace DotNetCoreTemplate.Api.ApiWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUserService _userService;

        public ValuesController(ITestService testService, IUserService userService)
        {
            _testService = testService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(ModelA model)
        {
            return Ok();
        }
    }
}
