using Core.Data;
using Core.DomainObjects;
using Data.Extensions;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Domain.Repository.User;
using Npgsql;

namespace Data.Repository.Users
{
    public class GroupQueryRepository : BaseQueryRepository<Group>, IGroupQueryRepository
    {
        public GroupQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<Group?> IQueryRepository<Group>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_group({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<Group>?> IQueryRepository<Group>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_group()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<Group?> Map(NpgsqlDataReader reader)
        {
            Group resulData = new Group();
            if(!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new Group(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idRole: Convert.ToInt32(reader["id_role"]),
                        name: Convert.ToString(reader["name"]),
                        description: Convert.ToString(reader["description"]),
                        isActive: Convert.ToBoolean(reader["is_active"]),
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
        protected override async Task<IEnumerable<Group>?> Maps(NpgsqlDataReader reader)
        {
            List<Group>? entities = new List<Group>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Group entity = new Group(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idRole: Convert.ToInt32(reader["id_role"]),
                        name: Convert.ToString(reader["name"]),
                        description: Convert.ToString(reader["description"]),
                        isActive: Convert.ToBoolean(reader["is_active"]),
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
