using Core.Data;
using Core.DomainObjects;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.User;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Users
{
    public class GroupCommandsRepository : BaseCommandsRepository<Group>, IGroupCommandsRepository
    {
        public GroupCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override Group Insert(Group entity)
        {
            string spName = "sp_insert_group";
            return base.Insert(entity, spName);
        }

        public override Group Update(Group entity)
        {
            string spName = "sp_update_group";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_group";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(Group entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);
        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(Group entity, NpgsqlCommand cmd)
        {
            //cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint, entity.Id);
            cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);
        }

        /// <summary>
        /// Passes the parameters to command for Delete Statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteCommandParameters(int id, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id", id);
        }

    }
}
