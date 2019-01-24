using System;
using System.Collections.Generic;
using Domain.Core.Models;

namespace Domain.Commands.Models
{
    public class Category: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        public virtual ICollection<CategoryField> CategoryFields { get; set; }

    }
}
