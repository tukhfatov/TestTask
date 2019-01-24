using System;
using Domain.Commands.Interfaces;
using Domain.Commands.Models;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestTaskDbContext context) : base(context)
        {

        }

    }
}
