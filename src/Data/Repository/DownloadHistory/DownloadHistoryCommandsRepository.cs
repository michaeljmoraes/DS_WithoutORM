
using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository
{
    public class DownloadHistoryCommandsRepository : BaseCommandsRepository<DownloadHistory>, IDownloadHistoryCommandsRepository
    {
        public DownloadHistoryCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override DownloadHistory Insert(DownloadHistory entity)
        {
            string spName = "sp_insert_download_history";
            return base.Insert(entity, spName);
        }

        public override DownloadHistory Update(DownloadHistory entity)
        {
            string spName = "sp_update_download_history";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_download_history";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(DownloadHistory entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_document", NpgsqlDbType.Bigint, entity.IdDocument);
            cmd.Parameters.AddWithValue("_id_user", NpgsqlDbType.Bigint, entity.IdUser);
            cmd.Parameters.AddWithValue("_downloaded_at", NpgsqlDbType.Date, entity.DownloadedAt);

        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(DownloadHistory entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_document", NpgsqlDbType.Bigint, entity.IdDocument);
            cmd.Parameters.AddWithValue("_id_user", NpgsqlDbType.Bigint, entity.IdUser);
            cmd.Parameters.AddWithValue("_downloaded_at", NpgsqlDbType.Date, entity.DownloadedAt);

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
