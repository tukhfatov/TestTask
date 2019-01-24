using System;
using System.Collections.Generic;
using Application.Dtos;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        void Add(CategoryDto category);

        IEnumerable<CategoryDto> GetAll();

        void Remove(int id);
    }
}
