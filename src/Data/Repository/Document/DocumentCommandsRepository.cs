
using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository
{
    public class DocumentCommandsRepository : BaseCommandsRepository<Document>, IDocumentCommandsRepository
    {
        public DocumentCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override Document Insert(Document entity)
        {
            string spName = "sp_insert_document";
            return base.Insert(entity, spName);
        }

        public override Document Update(Document entity)
        {
            string spName = "sp_update_document";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_document";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(Document entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_owner", NpgsqlDbType.Bigint, entity.IdOwner);
            cmd.Parameters.AddWithValue("_id_category", NpgsqlDbType.Bigint, entity.IdCategory);
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_file_name", NpgsqlDbType.Text, entity.FileName);
            cmd.Parameters.AddWithValue("_file_path", NpgsqlDbType.Text, entity.FilePath);
            cmd.Parameters.AddWithValue("_is_public", NpgsqlDbType.Boolean, entity.IsPublic);

        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(Document entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_id_owner", NpgsqlDbType.Bigint, entity.IdOwner);
            cmd.Parameters.AddWithValue("_id_category", NpgsqlDbType.Bigint, entity.IdCategory);
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);
            cmd.Parameters.AddWithValue("_file_name", NpgsqlDbType.Text, entity.FileName);
            cmd.Parameters.AddWithValue("_file_path", NpgsqlDbType.Text, entity.FilePath);
            cmd.Parameters.AddWithValue("_is_public", NpgsqlDbType.Boolean, entity.IsPublic);

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
