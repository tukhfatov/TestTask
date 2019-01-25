namespace Application.Dtos
{
    using System.Collections.Generic;

    public class ViewCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public  IList<CategoryFieldDto> CategoryFields { get; set; }
    }
}