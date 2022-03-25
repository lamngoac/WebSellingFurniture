using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;

namespace Web.Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public OrderRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion

        
        #region Methods
        public async Task<int> InsertOrder(Order order, List<OrderDetail> orderDetails)
        {
            // Kêt nối DB
            using (dbConnection = new MySqlConnection(connectionString))

            {
                var sqlCommand = "proc_insert_order_payment";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", order.UserId);
                parameters.Add("@UserName", order.UserName);
                parameters.Add("@FullName", order.FullName);
                parameters.Add("@Address", order.Address);
                parameters.Add("@PhoneNumber", order.PhoneNumber);
                parameters.Add("@PaymentMethods", (int)order.PaymentMethods);
                parameters.Add("@Note", order.Note);
                parameters.Add("@StatusOrder", order.StatusOrder);
                var res = await dbConnection.QueryFirstAsync<Order>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
                var rowsAffect = 0;
                if (!string.IsNullOrEmpty(res.OrderId.ToString()))
                {
                    var sqlCommand1 = "proc_insert_orderdetail";
                    foreach (var detail in orderDetails)
                    {
                        DynamicParameters parameters1 = new DynamicParameters();
                        parameters1.Add("@OrderId", res.OrderId);
                        parameters1.Add("@ProductId", detail.ProductId);
                        parameters1.Add("@Amount", detail.Amount);
                        parameters1.Add("@ProductName", detail.ProductName);
                        rowsAffect += await dbConnection.QueryFirstOrDefaultAsync<int>(sqlCommand1, param: parameters1, commandType: CommandType.StoredProcedure);
                    }
                }
                return rowsAffect;
            }
           
        }
        #endregion

    }
}
