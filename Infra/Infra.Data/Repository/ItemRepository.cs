using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Repository
{
    using System.Linq;
    using Context;
    using Domain.Commands.Interfaces;
    using Domain.Commands.Models;
    using Microsoft.EntityFrameworkCore;

    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(TestTaskDbContext context) : base(context)
        {

        }


        public IQueryable<Item> GetAllAsNoTracking()
        {
            return DbSet.Include(x => x.Category).Include(x => x.ItemValues).AsNoTracking();
        }
    }
}
