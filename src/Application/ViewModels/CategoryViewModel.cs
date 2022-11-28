using Core.DomainObjects;

namespace Domain.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
