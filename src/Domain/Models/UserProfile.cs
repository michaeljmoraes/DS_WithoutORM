using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class UserProfile : Entity, IAggregateRoot
    {
        [Column("id_role")]
        public Int64 IdRole { get; private set; }

        [Column("password")]
        public string Password { get; private set; }

        [Column("last_login")]
        public DateTime LastLogin { get; private set; }

        [Column("is_superuser")]
        public bool IsSuperuser { get; private set; }

        [Column("username")]
        public string Username { get; private set; }

        [Column("first_name")]
        public string FirstName { get; private set; }

        [Column("last_name")]
        public string LastName { get; private set; }

        [Column("email")]
        public string Email { get; private set; }

        [Column("is_active")]
        public bool IsActive { get; private set; }



        public UserProfile() { }

        public UserProfile(Int64 idRole, string password, DateTime lastLogin, bool isSuperuser, string username, string firstName, string lastName, string email, bool isActive, DateTime createdAt, DateTime updatedAt)
            : this(null, idRole, password, lastLogin, isSuperuser, username, firstName, lastName, email, isActive, createdAt, updatedAt)
        { }

        public UserProfile(Int64? id, Int64 idRole, string password, DateTime lastLogin, bool isSuperuser, string username, string firstName, string lastName, string email, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
            this.IdRole = idRole;
            this.Password = password;
            this.LastLogin = lastLogin;
            this.IsSuperuser = isSuperuser;
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
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
