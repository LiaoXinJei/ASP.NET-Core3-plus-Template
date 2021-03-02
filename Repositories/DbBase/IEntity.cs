using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DbBase
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
