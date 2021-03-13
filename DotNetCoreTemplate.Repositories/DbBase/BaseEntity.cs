using DotNetCoreTemplate.Repository.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.DbBase
{
    public class BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
