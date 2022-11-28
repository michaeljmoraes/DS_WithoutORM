using Core.DomainObjects;

namespace Domain.Models
{
    public class UserProfileViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public Int64 IdRole { get; set; }

        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsSuperuser { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
