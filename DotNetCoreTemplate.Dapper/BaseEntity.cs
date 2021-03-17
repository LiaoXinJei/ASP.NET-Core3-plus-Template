using DotNetCoreTemplate.Dapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Dapper
{
    public class BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
