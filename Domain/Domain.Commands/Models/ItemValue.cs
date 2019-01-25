using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Models
{
    using Core.Models;
    public class ItemValue: Entity
    {
        public virtual CategoryField Field { get; set; }

        public string FieldValue { get; set; }

        public virtual Item Item { get; set; }

    }
}
