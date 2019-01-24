using System;
using System.Collections.Generic;
using Domain.Commands.Models;
using Domain.Core.Commands;

namespace Domain.Commands.Commands
{
    public abstract class CategoryCommand: Command
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<string> CategoryFieldNames { get; set; }

        public IList<string> CategoryFieldTypes { get; set; }

    }
}
