using Core.Data;
using Core.DomainObjects;
using Data.Extensions;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Domain.Repository.User;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Repository.Users
{
    public class UserQueryRepository : BaseQueryRepository<UserProfile>, IUserQueryRepository
    {
        public UserQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        //public IUnityOfWork UnitOfWork => _uow;

        async Task<UserProfile?> IQueryRepository<UserProfile>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_user({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<UserProfile>?> IQueryRepository<UserProfile>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_user()";
            return await base.GetAllAsync(spName);
        }

        async Task<UserProfile?> IUserQueryRepository.GetByUserNameAsync(string userName)
        {
            string spName = $"select * from fn_get_user_byusername('{userName}')";
            UserProfile resulData;

            using (var cmd = _context.GetConnection().CreateCommand())
            {
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.Text;
                cmd.Prepare();
                using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    resulData = await Map(reader);
                }
            }

            return resulData;

        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<UserProfile?> Map(NpgsqlDataReader reader)
        {
            UserProfile resulData = new UserProfile();
            if(!reader.HasRows) return null;

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new UserProfile(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idRole: Convert.ToInt32(reader["id_role"]),
                        password: Convert.ToString(reader["password"]),
                        lastLogin: Convert.ToDateTime(reader["last_login"]),
                        isSuperuser: Convert.ToBoolean(reader["is_superuser"]),
                        username: Convert.ToString(reader["username"]),
                        firstName: Convert.ToString(reader["first_name"]),
                        lastName: Convert.ToString(reader["last_name"]),
                        email: Convert.ToString(reader["email"]),
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
        protected override async Task<IEnumerable<UserProfile>?> Maps(NpgsqlDataReader reader)
        {
            List<UserProfile>? entities = new List<UserProfile>();

            if (!reader.HasRows) return null;

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    //UserProfile entity = reader.ConvertToObject<UserProfile>();

                    UserProfile entity = new UserProfile(
                        id: Convert.ToInt64(reader["id"].ToString()),
                        idRole: Convert.ToInt64(reader["id_role"]),
                        password: Convert.ToString(reader["password"]),
                        lastLogin: Convert.ToDateTime(reader["last_login"]),
                        isSuperuser: Convert.ToBoolean(reader["is_superuser"]),
                        username: Convert.ToString(reader["username"]),
                        firstName: Convert.ToString(reader["first_name"]),
                        lastName: Convert.ToString(reader["last_name"]),
                        email: Convert.ToString(reader["email"]),
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
