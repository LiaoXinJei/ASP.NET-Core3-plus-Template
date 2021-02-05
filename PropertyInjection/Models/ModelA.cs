using PropertyInjection.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyInjection.Models
{
    public class ModelA
    {
        [ModelAValidtion]
        public string ReceiveABCOnly { get; set; }
    }
}
