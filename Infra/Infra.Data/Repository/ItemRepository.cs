using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repository
{
    using Context;
    using Domain.Commands.Interfaces;
    using Domain.Commands.Models;

    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(TestTaskDbContext context) : base(context)
        {

        }
    }
}
