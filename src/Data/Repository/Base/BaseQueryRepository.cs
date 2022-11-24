using System.Data;
using Core.DomainObjects;
using Npgsql;
using Core.Data;
using Domain.Repository.Base;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using FastMember;
using System.Runtime.InteropServices;

namespace Data.Repository.Base
{
    public abstract class BaseQueryRepository<T> where T : Entity, IAggregateRoot, new()
    {
        protected IDatabaseContext _context;

        public BaseQueryRepository(IDatabaseContext context) => _context = context;

        /// <summary>
        /// Base Method for Populate Data by key
        /// </summary>
        /// <param name="spName"></param>
        /// 
        /// <returns></returns>
        protected async Task<T?> GetAsync(string spName)
        {
            T resultData;
            using (var cmd = _context.GetConnection().CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.Text;
                cmd.Prepare();
                using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                {
                    resultData = await Map(reader);
                }

            }

            return resultData;
        }

        /// <summary>
        /// Base Method for Populate All Data
        /// </summary>
        /// <param name="getAllSql"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<T>?> GetAllAsync(string spName)
        {
            IEnumerable<T> listResult;

            using (var cmd = _context.GetConnection().CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.Text;
                cmd.Prepare();
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                listResult = await Maps(reader);
            }

            return listResult;
        }

        protected abstract Task<T?> Map(NpgsqlDataReader reader);
        protected abstract Task<IEnumerable<T>?> Maps(NpgsqlDataReader reader);

        public void Dispose()
        {
            _context.GetConnection().Close();
        }


    }

}
