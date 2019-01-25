using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    using Dtos;
    using Dtos.Item;

    public interface IItemService
    {
        void Add(AddItemDto item);

        IEnumerable<ViewItemDto> GetAll();

    }
}
