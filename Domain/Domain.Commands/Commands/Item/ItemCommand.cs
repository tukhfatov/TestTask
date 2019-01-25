using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Commands.Item
{
    using Core.Commands;
    public abstract class ItemCommand: Command
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public IList<int> CategoryFieldIds { get; set; }

        public IList<string> FieldValues { get; set; }

        public int CategoryId { get; set; }

    }
}
