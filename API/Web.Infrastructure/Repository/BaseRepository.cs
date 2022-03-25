using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;

namespace Web.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        #region Property
        /// <summary>
        /// Chuỗi kết nối Database
        /// </summary>
        protected string connectionString;
        
        /// <summary>
        /// Lấy tên bảng tương ứng với đối tượng
        /// </summary>
        string tableName = typeof(T).Name;

        /// <summary>
        /// Khởi tạo kết nối DB 
        /// </summary>
        protected IDbConnection dbConnection;

        /// <summary>
        /// Biến để lấy chuỗi kết nối từ appsettings.json cục bộ
        /// </summary>
        private IConfiguration _configuration;
        #endregion

        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString(Properties.DatabaseResources.ConnectionDB);
            tableName = typeof(T).Name;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Lấy danh sách đổi tượng 
        /// </summary>
        /// <returns>Thông tin danh sách đối tượng</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {

                //Thực thi với DB 
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureGetAll, tableName);
                var objects = await dbConnection.QueryAsync<T>(sqlCommand, commandType:CommandType.StoredProcedure);
                return objects;
            }
        }
        public async Task<IEnumerable<T>> GetDataHome()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // cái này m vừa thêm đâu đấy
                //Thực thi với DB 
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureGetDataHome, tableName);
                var objects = await dbConnection.QueryAsync<T>(sqlCommand, commandType: CommandType.StoredProcedure);
                return objects;
            }
        }

        public async Task<IEnumerable<T>> GetDataHot()
        {
            //Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // cái này m vừa thêm đâu đấy
                //Thực thi với DB 
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureGetDataHot, tableName);
                var objects = await dbConnection.QueryAsync<T>(sqlCommand, commandType: CommandType.StoredProcedure);
                return objects;
            }
        }
        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>Thông tin đối tượng theo Id</returns>
        public async Task<T> GetById(Guid entityId)
        {
            // Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Thực thi với DB
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureGetById, tableName);
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@_{tableName}Id", entityId);
                var entity = await dbConnection.QueryFirstOrDefaultAsync<T>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }
        /// <summary>
        /// Thêm bản ghi 
        /// </summary>
        /// <param name="entity">đối tượng thêm mới</param>
        /// <returns>Số bản ghi thêm mới</returns>
        public async Task<int> Insert(T entity)
        {
            // Kêt nối DB
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureInsert, tableName);
                DynamicParameters parameters = new DynamicParameters();
                var properties = typeof(T).GetProperties();
                //Add parameter 
                foreach (var property in properties)
                {
                    parameters.Add($"@_{property.Name}", property.GetValue(entity));
                }
                //Thực thi với DB             
                var rowsAffect = await dbConnection.QueryFirstOrDefaultAsync<int>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }


        /// <summary>
        /// Số bản ghi cập nhật
        /// </summary>
        /// <param name="entity">Đối tượng cập nhật</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        public async Task<int> Update(T entity)
        {
            // Kết nối DB
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // Thực thi với DB
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureUpdate, tableName);

                DynamicParameters parameters = new DynamicParameters();
                var properties = typeof(T).GetProperties();
                //Add parameter 
                foreach (var property in properties)
                {
                    parameters.Add($"@_{property.Name}", property.GetValue(entity));

                }

                var rowAffects = await dbConnection.QueryFirstOrDefaultAsync<int>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
                return rowAffects;
            }
        }
        /// <summary>
        /// Số bản ghi được xóa 
        /// </summary>
        /// <param name="entityId">ID đối tượng</param>
        /// <returns>Số bản ghi được xóa bỏ</returns>
        public async Task<int> Delete(Guid entityId)
        {
            // Kết nối DB 
            using (dbConnection = new MySqlConnection(connectionString))
            {
                //Thực thi với DB
                var sqlCommand = string.Format(Properties.DatabaseResources.ProcedureDelete, tableName);
                DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add(string.Format(Properties.DatabaseResources.ProcedureEntityId,tableName), entityId);
                dynamicParameters.Add($"@_{tableName}Id", entityId);
                var rowsAffects = await dbConnection.QueryFirstOrDefaultAsync<int>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsAffects;
            }
        }
        public async Task<Pagging<T>> GetPaggingAsync(Filter filter, int sortStatus, string fieldSort)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                // Tổng số nhà cung cấp có điều kiện.
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fil", filter.Fil);
                var totalRecord = await dbConnection.QueryFirstOrDefaultAsync<int>($"proc_get_total_{tableName}", param: parameters, commandType: CommandType.StoredProcedure);

                // Tính tổng số trang.
                var totalPages = Math.Ceiling((decimal)totalRecord / filter.PageSize);

                //Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
                var sqlCommand = $"proc_get_{tableName}s_filter";

                DynamicParameters parameters1 = new DynamicParameters();
                parameters1.Add("@pageindex", filter.PageIndex);
                parameters1.Add("@pagesize", filter.PageSize);
                parameters1.Add("@fil", filter.Fil);
                if (sortStatus >= 0)
                {
                    parameters1.Add("@sortstatus", sortStatus);
                    parameters1.Add("@fieldSort", fieldSort);
                }
                // lấy danh sách từ DB 
                var res = await dbConnection.QueryAsync<T>(sqlCommand, param: parameters1, commandType: CommandType.StoredProcedure);
                // Dữ liệu pagging 
                var paging = new Pagging<T>()
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
        #endregion 

    }
}
