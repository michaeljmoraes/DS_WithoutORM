
using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Npgsql;
using NpgsqlTypes;

namespace Data.Repository
{
    public class CategoryCommandsRepository : BaseCommandsRepository<Category>, ICategoryCommandsRepository
    {
        public CategoryCommandsRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        public override Category Insert(Category entity)
        {
            string spName = "sp_insert_category";
            return base.Insert(entity, spName);
        }

        public override Category Update(Category entity)
        {
            string spName = "sp_update_category";
            return base.Update(entity, spName);
        }

        public override int Delete(int id)
        {
            string spName = "sp_delete_category";
            return base.Delete(id, spName);
        }



        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(Category entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);

        }

        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(Category entity, NpgsqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("_name", NpgsqlDbType.Text, entity.Name);
            cmd.Parameters.AddWithValue("_description", NpgsqlDbType.Text, entity.Description);

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
