using Core.DomainObjects;

namespace Domain.Models
{
    public class DocumentViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public Int64 IdOwner { get; set; }

        public Int64 IdCategory { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}
