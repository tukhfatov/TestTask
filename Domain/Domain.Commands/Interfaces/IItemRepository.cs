using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Interfaces
{
    using Models;

    public interface IItemRepository : IRepository<Item>
    {
    }
}
