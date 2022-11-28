using Core.DomainObjects;

namespace Domain.Models
{
    public class UserGroupViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public Int64 IdUser { get; set; }

        public Int64 IdGroup { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
