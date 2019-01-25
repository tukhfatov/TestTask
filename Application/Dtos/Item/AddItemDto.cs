using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Item
{
    public class AddItemDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Category { get; set; }

        public IList<int> CategoryFieldIds { get; set; }

        public IList<string> CategoryValues { get; set; }
    }
}
