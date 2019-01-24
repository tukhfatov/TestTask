using System;
using System.Linq;
using Domain.Commands.Interfaces;
using Domain.Commands.Models;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class CategoryFieldTypeRepository : 
                                Repository<CategoryFieldType>, 
                                ICategoryFieldTypeRepository
    {
        public CategoryFieldTypeRepository(TestTaskDbContext context) : base(context)
        {

        }

        public CategoryFieldType GetByCode(string code)
        {
            return DbSet.FirstOrDefault(c => c.Code == code);
        }
    }
}
