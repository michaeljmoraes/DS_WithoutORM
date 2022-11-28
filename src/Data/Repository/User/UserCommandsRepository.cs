using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository.User;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository.Users
{
    public class UserCommandsRepository : BaseCommandsRepository<UserProfile>, IUserCommandsRepository
    {
        public UserCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override UserProfile Insert(UserProfile entity)
        {
            string spName = "sp_insert_user";
            return base.Insert(entity, spName);
        }

        public override UserProfile Update(UserProfile entity)
        {
            string spName = "sp_update_user";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            //string spName = "sp_inactive_user";
            string spName = "sp_delete_user";
            return base.Delete(id, spName);
        }

        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(UserProfile entity, NpgsqlCommand cmd)
        {
            //cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint, 0).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);
            cmd.Parameters.AddWithValue("_password", NpgsqlDbType.Text, entity.Password);
            cmd.Parameters.AddWithValue("_last_login", NpgsqlDbType.Date, entity.LastLogin);
            cmd.Parameters.AddWithValue("_is_superuser", NpgsqlDbType.Boolean, entity.IsSuperuser);
            cmd.Parameters.AddWithValue("_username", NpgsqlDbType.Text, entity.Username);
            cmd.Parameters.AddWithValue("_first_name", NpgsqlDbType.Text, entity.FirstName);
            cmd.Parameters.AddWithValue("_last_name", NpgsqlDbType.Text, entity.LastName);
            cmd.Parameters.AddWithValue("_email", NpgsqlDbType.Text, entity.Email);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);

            //cmd.Parameters.AddWithValue("_created_at", NpgsqlDbType.Date, entity.CreatedAt).Direction = ParameterDirection.Output;
            //cmd.Parameters.AddWithValue("_updated_at", NpgsqlDbType.Date, entity.UpdatedAt).Direction = ParameterDirection.Output;


        }
        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(UserProfile entity, NpgsqlCommand cmd)
        {
            //cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint, entity.Id);
            cmd.Parameters.AddWithValue("_id_role", NpgsqlDbType.Bigint, entity.IdRole);
            cmd.Parameters.AddWithValue("_password", NpgsqlDbType.Text, entity.Password);
            cmd.Parameters.AddWithValue("_last_login", NpgsqlDbType.Date, entity.LastLogin);
            cmd.Parameters.AddWithValue("_is_superuser", NpgsqlDbType.Boolean, entity.IsSuperuser);
            cmd.Parameters.AddWithValue("_username", NpgsqlDbType.Text, entity.Username);
            cmd.Parameters.AddWithValue("_first_name", NpgsqlDbType.Text, entity.FirstName);
            cmd.Parameters.AddWithValue("_last_name", NpgsqlDbType.Text, entity.LastName);
            cmd.Parameters.AddWithValue("_email", NpgsqlDbType.Text, entity.Email);
            cmd.Parameters.AddWithValue("_is_active", NpgsqlDbType.Boolean, entity.IsActive);

            //cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint, entity.Id);
            //cmd.Parameters.AddWithValue("_created_at", NpgsqlDbType.Date, entity.CreatedAt).Direction = ParameterDirection.Output;
            //cmd.Parameters.AddWithValue("_updated_at", NpgsqlDbType.Date, entity.UpdatedAt).Direction = ParameterDirection.Output;
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
