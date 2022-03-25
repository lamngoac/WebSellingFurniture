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
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public NewsRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<IEnumerable<News>> GetDataNewsProduct()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_news_product";
                DynamicParameters parameters = new DynamicParameters();
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<News>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        public async Task<IEnumerable<News>> GetDataNewsSale()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_news_sale";
                DynamicParameters parameters = new DynamicParameters();
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<News>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        public async Task<IEnumerable<News>> GetDataNewsEvent()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_news_event";
                DynamicParameters parameters = new DynamicParameters();
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<News>(sqlCommand, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
