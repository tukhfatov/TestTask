using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class AddCategoryDto
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public List<string> CategoryFieldNames { get; set; }


        public List<string> CategoryFieldTypes { get; set; }

    }
}
