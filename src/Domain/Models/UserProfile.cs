using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class UserProfile : Entity, IAggregateRoot
    {
        [Column("id_role")]
        public Int64 IdRole { get; private set; }
        [Column("password")]
        public string Password { get; private set; } = String.Empty;
        [Column("last_login")]
        public DateTime LastLogin { get; private set; }
        [Column("is_superuser")]
        public bool IsSuperuser { get; private set; }
        [Column("username")]
        public string Username { get; private set; } = String.Empty;
        [Column("first_name")]
        public string FirstName { get; private set; } = String.Empty;
        [Column("last_name")]
        public string LastName { get; private set; } = String.Empty;
        [Column("email")]
        public string Email { get; private set; } = String.Empty;
        [Column("is_active")]
        public bool IsActive { get; private set; }

        public UserProfile() { }

        public UserProfile(int idRole, string password, DateTime lastLogin, bool isSuperuser, 
            string username, bool isActive, string firstName, string lastName, string email,
                            DateTime createdAt, DateTime updatedAt)
            : this(null, idRole, password, lastLogin, isSuperuser, username, firstName, 
                  lastName, email, isActive,createdAt, updatedAt) { }

        public UserProfile(Int64? id, Int64 idRole, string password, DateTime lastLogin, 
            bool isSuperuser, string username, string firstName, string lastName, 
            string email, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id??0;
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
            return $"{Username}";
        }

        public void Validate()
        {
            Validations.ValidateNotEqual("^[a-zA-Z0-9]*$", Username, "UserName isn't a alphanumeric");
            Validations.ValidateEmpty(Username, "UserName could not be empty");
            Validations.ValidateLength(Username, 14, "UserName exceeds maximum 14 characters");

            Validations.ValidateEmpty(Email, "Email could not be empty");

        }
    }
}
