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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        #endregion

        #region Methods
        public async Task<Pagging<Product>> GetProductPaggingAsync(Filter filter, int sortStatus, string fieldSort,string categoryId, int price)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // Tổng số nhà cung cấp có điều kiện.
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fil", filter.Fil);
                parameters.Add("@categoryId", categoryId);
                parameters.Add("@price", price);
                var totalRecord = await dbConnection.QueryFirstOrDefaultAsync<int>($"proc_get_total_Product", param: parameters, commandType: CommandType.StoredProcedure);

                // Tính tổng số trang.
                var totalPages = Math.Ceiling((decimal)totalRecord / filter.PageSize);

                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_Products_filter";

                DynamicParameters parameters1 = new DynamicParameters();
                parameters1.Add("@pageindex", filter.PageIndex);
                parameters1.Add("@pagesize", filter.PageSize);
                parameters1.Add("@fil", filter.Fil);
                if (sortStatus >= 0)
                {
                    parameters1.Add("@sortstatus", sortStatus);
                    parameters1.Add("@fieldSort", fieldSort);
                }
                parameters1.Add("@categoryId", categoryId);
                parameters1.Add("@price", price);
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<Product>(sqlCommand, param: parameters1, commandType: CommandType.StoredProcedure);
                // Dữ liệu pagging 
                var paging = new Pagging<Product>()
                {
                    TotalRecord = totalRecord,
                    TotalPages = (int)totalPages,
                    Data = res,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize
                };
                return paging;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsTopSelling(int number = 1)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_procducts_top_selling";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@number",number);
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<Product>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
