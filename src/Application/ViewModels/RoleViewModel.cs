using Core.DomainObjects;

namespace Domain.Models
{
    public class RoleViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string RoleType { get; set; }

        public string Domain { get; set; }

        public string Action { get; set; }

        public bool IsActive { get; set; }

        public int Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
