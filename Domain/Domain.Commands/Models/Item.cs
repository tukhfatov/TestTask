using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Models
{
    using Core.Models;
    public class Item: Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public virtual Category Category { get; set; }

        public virtual IList<ItemValue> ItemValues { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

    }
}
