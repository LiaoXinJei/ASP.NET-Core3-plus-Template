using DotNetCoreTemplate.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTemplate.Models
{
    public class ModelA
    {
        [ModelAValidtion]
        public string ReceiveABCOnly { get; set; }
    }
}
