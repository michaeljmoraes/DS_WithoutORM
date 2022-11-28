using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class DownloadHistoryQueryRepository : BaseQueryRepository<DownloadHistory>, IDownloadHistoryQueryRepository
    {
        public DownloadHistoryQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<DownloadHistory?> IQueryRepository<DownloadHistory>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_download_history({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<DownloadHistory>?> IQueryRepository<DownloadHistory>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_download_history()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<DownloadHistory?> Map(NpgsqlDataReader reader)
        {
            DownloadHistory resulData = new DownloadHistory();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new DownloadHistory(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idDocument: Convert.ToInt64(reader["id_document"].ToString()),
idUser: Convert.ToInt64(reader["id_user"].ToString()),
downloadedAt: Convert.ToDateTime(reader["downloaded_at"].ToString()));
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
        protected override async Task<IEnumerable<DownloadHistory>?> Maps(NpgsqlDataReader reader)
        {
            List<DownloadHistory>? entities = new List<DownloadHistory>();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    DownloadHistory entity = new DownloadHistory(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idDocument: Convert.ToInt64(reader["id_document"].ToString()),
idUser: Convert.ToInt64(reader["id_user"].ToString()),
downloadedAt: Convert.ToDateTime(reader["downloaded_at"].ToString()));

                    entities.Add(entity);
                }
                await reader.CloseAsync();
            }
            return entities;
        }
    }
}
