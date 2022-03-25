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
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public OrderDetailRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByIdAsync(Guid OrderId)
        {
            // Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Thực thi với DB
                var sqlCommand = "webnoithat.proc_get_orderDetails_by_OrderId";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@OrderId", OrderId);
                var res = await dbConnection.QueryAsync<OrderDetail>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
