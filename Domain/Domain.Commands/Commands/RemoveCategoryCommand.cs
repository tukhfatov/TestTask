using System;
using Domain.Core.Commands;

namespace Domain.Commands.Commands
{
    public class RemoveCategoryCommand : CategoryCommand
    {
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
