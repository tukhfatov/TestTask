using System;
using Domain.Commands.Models;

namespace Domain.Commands.Interfaces
{
    public interface ICategoryFieldTypeRepository : IRepository<CategoryFieldType>
    {

        CategoryFieldType GetByCode(string code);

    }
}
