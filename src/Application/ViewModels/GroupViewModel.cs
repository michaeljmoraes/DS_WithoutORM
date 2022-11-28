using Core.DomainObjects;

namespace Domain.Models
{
    public class GroupViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public Int64 IdRole { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
