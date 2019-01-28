using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Item
{
    public class SearchItemDto
    {
        public SearchItemDto()
        {
            Fields = new List<SearchItemFieldDto>();
        }

        public int CategoryId { get; set; }

        public IList<SearchItemFieldDto> Fields { get; set; }
    }
}
