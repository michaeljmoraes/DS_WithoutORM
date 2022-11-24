using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role: Entity, IAggregateRoot
    {
        public string Name { get; private set; } = String.Empty;
        public string? Description { get; private set; } = String.Empty;
        public string RoleType { get; private set; } = String.Empty;
        public string Domain { get; private set; } = String.Empty;
        public string Action { get; private set; } = String.Empty;
        public bool IsActive { get; private set; }
        public int Priority { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Role() { }

        public Role(string name, string? description, string roleType, string domain, string action, bool isActive, int priority, DateTime createdAt, DateTime updatedAt)
        {
            this.Name = name;
            this.Description = description;
            this.RoleType = roleType;
            this.Domain = domain;
            this.Action = action;
            this.IsActive = isActive;
            this.Priority = priority;

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;


    }

    public override string ToString()
        {
            return $"{Name}";
        }

        public void Validate()
        {
            Validations.ValidateEmpty(Name, "Name could not be empty");
            Validations.ValidateLength(Name, 100, "Name exceeds maximum 100 characters");

            Validations.ValidateLength(Description ?? "", 300, "Description exceeds maximum 400 characters");

        }
    }
}
