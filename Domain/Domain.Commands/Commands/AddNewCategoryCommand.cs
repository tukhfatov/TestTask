using System;
using System.Collections.Generic;
using Domain.Commands.Models;

namespace Domain.Commands.Commands
{
    public class AddNewCategoryCommand : CategoryCommand
    {
        public AddNewCategoryCommand(string name, string description,
            List<string> categoryFieldNames, List<string> categoryFieldTypes )
        {
//            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            CategoryFieldNames = categoryFieldNames;
            CategoryFieldTypes = categoryFieldTypes;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
