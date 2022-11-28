using Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class DownloadHistory : Entity, IAggregateRoot
    {
        [Column("id_document")]
        public Int64 IdDocument { get; private set; }

        [Column("id_user")]
        public Int64 IdUser { get; private set; }

        [Column("downloaded_at")]
        public DateTime DownloadedAt { get; private set; }



        public DownloadHistory() { }

        public DownloadHistory(Int64 idDocument, Int64 idUser, DateTime downloadedAt)
            : this(null, idDocument, idUser, downloadedAt)
        { }

        public DownloadHistory(Int64? id, Int64 idDocument, Int64 idUser, DateTime downloadedAt)
        {
            this.Id = id ?? 0;
            this.IdDocument = idDocument;
            this.IdUser = idUser;
            this.DownloadedAt = downloadedAt;

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
