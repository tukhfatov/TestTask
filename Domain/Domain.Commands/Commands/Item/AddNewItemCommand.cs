using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands.Commands.Item
{
    public class AddNewItemCommand: ItemCommand
    {
        public AddNewItemCommand(string name, string description, int price, int category, IList<int> categoryFieldIds, IList<string> fieldValues)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = category;
            CategoryFieldIds = categoryFieldIds;
            FieldValues = fieldValues;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
