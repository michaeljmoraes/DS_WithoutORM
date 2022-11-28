using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Role : Entity, IAggregateRoot
    {
        [Column("name")]
        public string Name { get; private set; }

        [Column("description")]
        public string Description { get; private set; }

        [Column("role_type")]
        public string RoleType { get; private set; }

        [Column("domain")]
        public string Domain { get; private set; }

        [Column("action")]
        public string Action { get; private set; }

        [Column("is_active")]
        public bool IsActive { get; private set; }

        [Column("priority")]
        public int Priority { get; private set; }



        public Role() { }

        public Role(string name, string description, string roleType, string domain, string action, bool isActive, int priority, DateTime createdAt, DateTime updatedAt)
            : this(null, name, description, roleType, domain, action, isActive, priority, createdAt, updatedAt)
        { }

        public Role(Int64? id, string name, string description, string roleType, string domain, string action, bool isActive, int priority, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
            this.Name = name;
            this.Description = description;
            this.RoleType = roleType;
            this.Domain = domain;
            this.Action = action;
            this.IsActive = isActive;
            this.Priority = priority;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

            Validate();
        }


        public override string ToString()
        {
            return $"";
        }

        public void Validate()
        {
            //Validations.ValidateEmpty(Name, "Name could not be empty");
            //Validations.ValidateLength(Name, 100, "Name exceeds maximum 100 characters");

            //Validations.ValidateLength(Description ?? "", 300, "Description exceeds maximum 400 characters");

        }
    }
}
