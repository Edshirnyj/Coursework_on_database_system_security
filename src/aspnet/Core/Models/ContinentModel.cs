using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ContinentModel
    {
        public Guid ContinentId { get; set; }
        public string? Name { get; set; }

        private ContinentModel(Guid continentId, string? name)
        {
            ContinentId = continentId;
            Name = name;
        }

        public static (ContinentModel ContinentModel, string Error) Create(Guid continentId, string? name)
        {
            string? error = ValidateInputs(name);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var continentModel = new ContinentModel(continentId, name);
            return (continentModel, string.Empty);
        }

        private static string? ValidateInputs(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Continent name cannot be empty.";

            return string.Empty;
        }
    }
}