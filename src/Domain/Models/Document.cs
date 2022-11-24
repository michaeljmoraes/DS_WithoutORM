using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class Document : Entity, IAggregateRoot
    {
        public int IdOwner { get; private set; }
        public int IdCategory { get; private set; }
        public string? Name { get; private set; } = String.Empty;
        public string? Description { get; private set; } = String.Empty;
        public string? FileName { get; private set; } = String.Empty;
        public string? FilePath { get; private set; } = String.Empty;
        public bool IsPublic { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Document(int idOwner, int idCategory, string name, string description, string fileName, string filePath, bool isPublic, DateTime createdAt, DateTime updatedAt) 
        {
            this.IdOwner = idOwner;
            this.IdCategory = idCategory;
            this.Name = name;
            this.Description = description;
            this.FileName = fileName;
            this.FilePath = filePath;
            this.IsPublic = isPublic;
            
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

            Validate();
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void Validate()
        {
            Validations.ValidateEmpty(Name ?? "", "Name could not be empty");
            Validations.ValidateLength(Name ?? "", 100, "Name exceeds maximum 100 characters");

            Validations.ValidateLength(Description ?? "", 300, "Description exceeds maximum 300 characters");
        }
    }
}
