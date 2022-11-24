using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GroupViewModel : BaseViewModel
    {
        public int IdRole { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
