using Core.Data;
using Data.Repository.Base;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Base;
using Npgsql;

namespace Data.Repository
{
    public class UserProfileQueryRepository : BaseQueryRepository<UserProfile>, IUserProfileQueryRepository
    {
        public UserProfileQueryRepository(IDatabaseContext databaseContext) : base(databaseContext) { }

        async Task<UserProfile?> IQueryRepository<UserProfile>.GetAsync(int id)
        {
            string spName = $"select * from fn_get_user_profile({id})";
            return await base.GetAsync(spName);
        }

        async Task<IEnumerable<UserProfile>?> IQueryRepository<UserProfile>.GetAllAsync()
        {
            string spName = "select * from fn_get_all_user_profile()";
            return await base.GetAllAsync(spName);
        }


        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<UserProfile?> Map(NpgsqlDataReader reader)
        {
            UserProfile resulData = new UserProfile();
            if (!reader.HasRows) return null;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    resulData = new UserProfile(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idRole: Convert.ToInt64(reader["id_role"].ToString()),
password: Convert.ToString(reader["password"].ToString()),
lastLogin: Convert.ToDateTime(reader["last_login"].ToString()),
isSuperuser: Convert.ToBoolean(reader["is_superuser"].ToString()),
username: Convert.ToString(reader["username"].ToString()),
firstName: Convert.ToString(reader["first_name"].ToString()),
lastName: Convert.ToString(reader["last_name"].ToString()),
email: Convert.ToString(reader["email"].ToString()),
isActive: Convert.ToBoolean(reader["is_active"].ToString()),

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
                    UserProfile entity = new UserProfile(
                        id: Convert.ToInt32(reader["id"].ToString()),
                        idRole: Convert.ToInt64(reader["id_role"].ToString()),
password: Convert.ToString(reader["password"].ToString()),
lastLogin: Convert.ToDateTime(reader["last_login"].ToString()),
isSuperuser: Convert.ToBoolean(reader["is_superuser"].ToString()),
username: Convert.ToString(reader["username"].ToString()),
firstName: Convert.ToString(reader["first_name"].ToString()),
lastName: Convert.ToString(reader["last_name"].ToString()),
email: Convert.ToString(reader["email"].ToString()),
isActive: Convert.ToBoolean(reader["is_active"].ToString()),

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
