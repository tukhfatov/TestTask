using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Interfaces
{
    using System.Linq;
    using Models;

    public interface IItemRepository : IRepository<Item>
    {
        IQueryable<Item> GetAllAsNoTracking();
    }
}
