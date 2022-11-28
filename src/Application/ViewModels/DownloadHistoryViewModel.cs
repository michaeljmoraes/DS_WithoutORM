using Core.DomainObjects;

namespace Domain.Models
{
    public class DownloadHistoryViewModel : BaseViewModel
    {
        public Int64 Id { get; set; }

        public Int64 IdDocument { get; set; }

        public Int64 IdUser { get; set; }

        public DateTime DownloadedAt { get; set; }


    }
}
