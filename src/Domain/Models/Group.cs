using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Group : Entity, IAggregateRoot
    {

        [Column("id_role")]
        public Int64 IdRole { get; private set; }
        [Column("name")]
        public string Name { get; private set; } = String.Empty;
        [Column("description")]
        public string? Description { get; private set; }
        public bool IsActive { get; private set; } = false;

        public Group() { }

        public Group(Int64 idRole, string name, string? description, bool isActive,
            DateTime createdAt, DateTime updatedAt)
            :
            this(null, idRole, name, description,
            isActive, createdAt, updatedAt)
        { }

        public Group(Int64? id, Int64 idRole, string name, string? description, 
            bool isActive, DateTime createdAt, DateTime updatedAt) 
        {
            this.Id = id??0;
            this.IdRole = idRole;
            this.Name = name;
            this.Description = description;
            this.IsActive = isActive;

            this.UpdatedAt = updatedAt;
            this.CreatedAt = createdAt;

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

            Validations.ValidateLength(Description ?? "", 300, "Description exceeds maximum 400 characters");

        }
    }
}
