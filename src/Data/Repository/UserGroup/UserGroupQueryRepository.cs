using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class UserGroupQueryRepository : BaseQueryRepository<UserGroup>, IUserGroupQueryRepository
    {
        public UserGroupQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<UserGroup?> IQueryRepository<UserGroup>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_user_group({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<UserGroup>?> IQueryRepository<UserGroup>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_user_group()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<UserGroup?> Map(NpgsqlDataReader reader)
        {
            UserGroup resulData = new UserGroup();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new UserGroup(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idUser: Convert.ToInt64(reader["id_user"].ToString()),
idGroup: Convert.ToInt64(reader["id_group"].ToString()),

                        createdAt: Convert.ToDateTime(reader["created_at"]),
                        updatedAt: Convert.ToDateTime(reader["updated_at"]));
                }
                await reader.CloseAsync();
            }
            return resulData;
        }

        /// <summary>
        /// Maps data for populate all statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<IEnumerable<UserGroup>?> Maps(NpgsqlDataReader reader)
        {
            List<UserGroup>? entities = new List<UserGroup>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    UserGroup entity = new UserGroup(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idUser: Convert.ToInt64(reader["id_user"].ToString()),
idGroup: Convert.ToInt64(reader["id_group"].ToString()),

                        createdAt: Convert.ToDateTime(reader["created_at"]),
                        updatedAt: Convert.ToDateTime(reader["updated_at"]));

                    entities.Add(entity);
                }
                await reader.CloseAsync();
            }
            return entities;
        }
    }
}
