using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Group : Entity, IAggregateRoot
    {
        [Column("id_role")]
        public Int64 IdRole { get; private set; }

        [Column("name")]
        public string Name { get; private set; }

        [Column("description")]
        public string Description { get; private set; }

        [Column("is_active")]
        public bool IsActive { get; private set; }



        public Group() { }

        public Group(Int64 idRole, string name, string description, bool isActive, DateTime createdAt, DateTime updatedAt)
            : this(null, idRole, name, description, isActive, createdAt, updatedAt)
        { }

        public Group(Int64? id, Int64 idRole, string name, string description, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
            this.IdRole = idRole;
            this.Name = name;
            this.Description = description;
            this.IsActive = isActive;
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
