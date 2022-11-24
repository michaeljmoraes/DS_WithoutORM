using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Category() { }

        public Category(string name, string? description, 
            DateTime createdAt, DateTime updatedAt) 
        {
            this.Name = name;
            this.Description = description;

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

            Validate();
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void Validate()
        {
            Validations.ValidateEmpty(Name, "Name could not be empty");
            Validations.ValidateLength(Name, 100, "Name exceeds maximum 100 characters");

            Validations.ValidateLength(Description ?? "", 300, "Description exceeds maximum 300 characters");
        }

    }
}
