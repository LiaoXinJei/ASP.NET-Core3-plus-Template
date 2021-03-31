using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreTemplate.Api.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreTemplate.Service.Interface;

namespace DotNetCoreTemplate.Api.ApiWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _userService.GetAll();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(ModelA model)
        {
            return Ok();
        }
    }
}
