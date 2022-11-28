
using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository
{
    public class RoleCommandsRepository : BaseCommandsRepository<Role>, IRoleCommandsRepository
    {
        public RoleCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override Role Insert(Role entity)
        {
            string spName = "sp_insert_role";
            return base.Insert(entity, spName);
        }

        public override Role Update(Role entity)
        {
            string spName = "sp_update_role";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_role";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(Role entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_role_type", NpgsqlDbType.Text, entity.RoleType);
            cmd.Parameters.AddWithValue("_domain", NpgsqlDbType.Text, entity.Domain);
            cmd.Parameters.AddWithValue("_action", NpgsqlDbType.Text, entity.Action);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);
            cmd.Parameters.AddWithValue("_priority", NpgsqlDbType.Integer, entity.Priority);

        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(Role entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_role_type", NpgsqlDbType.Text, entity.RoleType);
            cmd.Parameters.AddWithValue("_domain", NpgsqlDbType.Text, entity.Domain);
            cmd.Parameters.AddWithValue("_action", NpgsqlDbType.Text, entity.Action);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);
            cmd.Parameters.AddWithValue("_priority", NpgsqlDbType.Integer, entity.Priority);

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
