using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class UserGroup : Entity, IAggregateRoot
    {
        [Column("id_user")]
        public Int64 IdUser { get; private set; }

        [Column("id_group")]
        public Int64 IdGroup { get; private set; }



        public UserGroup() { }

        public UserGroup(Int64 idUser, Int64 idGroup, DateTime createdAt, DateTime updatedAt)
            : this(null, idUser, idGroup, createdAt, updatedAt)
        { }

        public UserGroup(Int64? id, Int64 idUser, Int64 idGroup, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
            this.IdUser = idUser;
            this.IdGroup = idGroup;
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
