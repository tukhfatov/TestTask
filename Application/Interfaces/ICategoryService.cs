using System;
using System.Collections.Generic;
using Application.Dtos;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        void Add(AddCategoryDto addCategory);

        IEnumerable<ViewCategoryDto> GetAll();

        void Remove(int id);
    }
}
