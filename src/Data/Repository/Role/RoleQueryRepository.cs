using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class RoleQueryRepository : BaseQueryRepository<Role>, IRoleQueryRepository
    {
        public RoleQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<Role?> IQueryRepository<Role>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_role({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<Role>?> IQueryRepository<Role>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_role()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<Role?> Map(NpgsqlDataReader reader)
        {
            Role resulData = new Role();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new Role(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),
roleType: Convert.ToString(reader["role_type"].ToString()),
domain: Convert.ToString(reader["domain"].ToString()),
action: Convert.ToString(reader["action"].ToString()),
isActive: Convert.ToBoolean(reader["is_active"].ToString()),
priority: Convert.ToInt32(reader["priority"].ToString()),

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
        protected override async Task<IEnumerable<Role>?> Maps(NpgsqlDataReader reader)
        {
            List<Role>? entities = new List<Role>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Role entity = new Role(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),
roleType: Convert.ToString(reader["role_type"].ToString()),
domain: Convert.ToString(reader["domain"].ToString()),
action: Convert.ToString(reader["action"].ToString()),
isActive: Convert.ToBoolean(reader["is_active"].ToString()),
priority: Convert.ToInt32(reader["priority"].ToString()),

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
