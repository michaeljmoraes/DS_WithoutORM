using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class DocumentQueryRepository : BaseQueryRepository<Document>, IDocumentQueryRepository
    {
        public DocumentQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<Document?> IQueryRepository<Document>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_document({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<Document>?> IQueryRepository<Document>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_document()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<Document?> Map(NpgsqlDataReader reader)
        {
            Document resulData = new Document();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new Document(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idOwner: Convert.ToInt64(reader["id_owner"].ToString()),
idCategory: Convert.ToInt64(reader["id_category"].ToString()),
name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),
fileName: Convert.ToString(reader["file_name"].ToString()),
filePath: Convert.ToString(reader["file_path"].ToString()),
isPublic: Convert.ToBoolean(reader["is_public"].ToString()),

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
        protected override async Task<IEnumerable<Document>?> Maps(NpgsqlDataReader reader)
        {
            List<Document>? entities = new List<Document>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    Document entity = new Document(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idOwner: Convert.ToInt64(reader["id_owner"].ToString()),
idCategory: Convert.ToInt64(reader["id_category"].ToString()),
name: Convert.ToString(reader["name"].ToString()),
description: Convert.ToString(reader["description"].ToString()),
fileName: Convert.ToString(reader["file_name"].ToString()),
filePath: Convert.ToString(reader["file_path"].ToString()),
isPublic: Convert.ToBoolean(reader["is_public"].ToString()),

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
