using Core.Data;
using Core.DomainObjects;
using Domain.Repository.Base;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Data.Repository.Base
{
    public abstract class BaseCommandsRepository<T> : ICommandsRepository<T> where T : Entity, IAggregateRoot, new()
    {
        private IDatabaseContext _context;
        public BaseCommandsRepository(IDatabaseContext context) => _context = context;

        /// <summary>
        /// Base Method for Insert Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <returns></returns>
        protected virtual T Insert(T entity, string spName)
        {
            int i = 0;
            try
            {
                using (var cmd = _context.GetConnection().CreateCommand())
                {
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint).Direction = ParameterDirection.Output;

                    InsertCommandParameters(entity, cmd);

                    cmd.Parameters.AddWithValue("_created_at", NpgsqlDbType.Date).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("_updated_at", NpgsqlDbType.Date).Direction = ParameterDirection.Output;

                    i = cmd.ExecuteNonQuery();

                    entity.Id = Convert.ToInt64(cmd.Parameters["_id"].Value);
                    entity.CreatedAt = Convert.ToDateTime(cmd.Parameters["_created_at"].Value);
                    entity.UpdatedAt = Convert.ToDateTime(cmd.Parameters["_updated_at"].Value);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        /// <summary>
        /// Base Method for Update Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateSql"></param>
        /// <returns></returns>
        protected virtual T Update(T entity, string spName)
        {
            int i = 0;
            using (var cmd = _context.GetConnection().CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_id", NpgsqlDbType.Bigint, entity.Id).Direction = ParameterDirection.InputOutput;

                UpdateCommandParameters(entity, cmd);

                cmd.Parameters.AddWithValue("_created_at", NpgsqlDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("_updated_at", NpgsqlDbType.Date).Direction = ParameterDirection.Output;

                i = cmd.ExecuteNonQuery();

                entity.Id = Convert.ToInt64(cmd.Parameters["_id"].Value);
                entity.CreatedAt = Convert.ToDateTime(cmd.Parameters["_created_at"].Value);
                entity.UpdatedAt = Convert.ToDateTime(cmd.Parameters["_updated_at"].Value);

            }
            return entity;
        }

        /// <summary>
        /// Base Method for Delete Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleteSql"></param>
        /// <returns></returns>
        protected virtual int Delete(int id, string spName)
        {
            int i = 0;
            using (var cmd = _context.GetConnection().CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                DeleteCommandParameters(id, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        protected abstract void InsertCommandParameters(T entity, NpgsqlCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, NpgsqlCommand cmd);
        protected abstract void DeleteCommandParameters(int id, NpgsqlCommand cmd);

        public void Dispose()
        {
            _context.GetConnection().Close();
        }

        public abstract T Insert(T entity);
        public abstract T Update(T entity);
        public abstract int Delete(int id);
    }
}
