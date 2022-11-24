using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class UserProfileViewModel : BaseViewModel
    {
        public int IdRole { get; set; }
        public string Password { get; set; } = String.Empty;
        public DateTime LastLogin { get; set; } 
        public bool IsSuperuser { get; set; }
        public string Username { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public bool IsActive { get; set; }
    }
}
