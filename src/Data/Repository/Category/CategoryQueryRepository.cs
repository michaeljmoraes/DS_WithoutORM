using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class CategoryQueryRepository : BaseQueryRepository<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<Category?> IQueryRepository<Category>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_category({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<Category>?> IQueryRepository<Category>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_category()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<Category?> Map(NpgsqlDataReader reader)
        {
            Category resulData = new Category();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new Category(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),

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
        protected override async Task<IEnumerable<Category>?> Maps(NpgsqlDataReader reader)
        {
            List<Category>? entities = new List<Category>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Category entity = new Category(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),

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
