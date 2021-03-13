using DotNetCoreTemplate.Api.ApiAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTemplate.Api.ApiModels
{
    public class ModelA
    {
        [ModelAValidtion]
        public string ReceiveABCOnly { get; set; }
    }
}
