using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DownloadHistory : Entity
    {
        public int IdDocument { get; private set; }
        public int IdUser { get; set; }
        public DateTime DownloadedAt { get; private set; }

        public DownloadHistory() { }
        
        public DownloadHistory(int idDocument, int idUser, DateTime downloadedAt)
        {
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

        }

    }
}
