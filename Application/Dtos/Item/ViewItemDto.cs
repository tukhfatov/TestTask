using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Item
{
    public class ViewItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public IList<ItemValueDto> ItemValues { get; set; } 
    }
}
