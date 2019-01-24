using System;
using Domain.Commands.Interfaces;
using Domain.Commands.Models;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class CategoryFieldRepository:
                                Repository<CategoryField>,
                                ICategoryFieldRepository
    {
        public CategoryFieldRepository(TestTaskDbContext context) : base(context)
        {

        }
    }
}
