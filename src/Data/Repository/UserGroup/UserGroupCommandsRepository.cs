
using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository
{
    public class UserGroupCommandsRepository : BaseCommandsRepository<UserGroup>, IUserGroupCommandsRepository
    {
        public UserGroupCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override UserGroup Insert(UserGroup entity)
        {
            string spName = "sp_insert_user_group";
            return base.Insert(entity, spName);
        }

        public override UserGroup Update(UserGroup entity)
        {
            string spName = "sp_update_user_group";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_user_group";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(UserGroup entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_user", NpgsqlDbType.Bigint, entity.IdUser);
            cmd.Parameters.AddWithValue("_id_group", NpgsqlDbType.Bigint, entity.IdGroup);

        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(UserGroup entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_user", NpgsqlDbType.Bigint, entity.IdUser);
            cmd.Parameters.AddWithValue("_id_group", NpgsqlDbType.Bigint, entity.IdGroup);

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
