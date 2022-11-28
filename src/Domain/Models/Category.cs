using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        [Column("name")]
        public string Name { get; private set; }

        [Column("description")]
        public string Description { get; private set; }



        public Category() { }

        public Category(string name, string description, DateTime createdAt, DateTime updatedAt)
            : this(null, name, description, createdAt, updatedAt)
        { }

        public Category(Int64? id, string name, string description, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
            this.Name = name;
            this.Description = description;
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
