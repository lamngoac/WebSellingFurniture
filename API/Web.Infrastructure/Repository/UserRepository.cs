using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;

namespace Web.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Contructor
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            // Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Thực thi với DB
                var sqlCommand = "proc_get_user_by_username";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@_UserName", userName);
                var user = await dbConnection.QueryFirstOrDefaultAsync<User>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
        #endregion




    }
}
