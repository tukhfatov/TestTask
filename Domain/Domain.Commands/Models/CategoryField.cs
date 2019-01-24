using System;
using Domain.Core.Models;

namespace Domain.Commands.Models
{
    public class CategoryField : Entity
    {

        public string Name { get; set; }

        // TODO: not implemented Desciption field

        public string Description { get; set; } 

        public virtual CategoryFieldType CategoryFieldType { get; set; }

        public virtual Category Category { get; set; }

    }
}
