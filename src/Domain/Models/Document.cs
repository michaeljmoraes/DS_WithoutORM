using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Document : Entity, IAggregateRoot
    {
        [Column("id_owner")]
        public Int64 IdOwner { get; private set; }

        [Column("id_category")]
        public Int64 IdCategory { get; private set; }

        [Column("name")]
        public string Name { get; private set; }

        [Column("description")]
        public string Description { get; private set; }

        [Column("file_name")]
        public string FileName { get; private set; }

        [Column("file_path")]
        public string FilePath { get; private set; }

        [Column("is_public")]
        public bool IsPublic { get; private set; }



        public Document() { }

        public Document(Int64 idOwner, Int64 idCategory, string name, string description, string fileName, string filePath, bool isPublic, DateTime createdAt, DateTime updatedAt)
            : this(null, idOwner, idCategory, name, description, fileName, filePath, isPublic, createdAt, updatedAt)
        { }

        public Document(Int64? id, Int64 idOwner, Int64 idCategory, string name, string description, string fileName, string filePath, bool isPublic, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id ?? 0;
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
