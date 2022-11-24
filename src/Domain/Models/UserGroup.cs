using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserGroup: Entity
    {
        public int IdUser { get; private set; }
        public int IdGroup { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public UserGroup(int idUser, int idGroup, DateTime createdAt, DateTime updatedAt)
        {
            this.IdUser = idUser;
            this.IdGroup = idGroup;

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;

        }
    }
}
