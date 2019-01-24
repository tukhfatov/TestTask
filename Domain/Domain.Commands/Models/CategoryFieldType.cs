using System;
using Domain.Core.Models;

namespace Domain.Commands.Models
{
    public class CategoryFieldType: Entity
    {
        #region TYPES

        public const string BooleanType = "bool";
        public const string StringType = "string";
        public const string IntegerType = "integer";

        #endregion

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
