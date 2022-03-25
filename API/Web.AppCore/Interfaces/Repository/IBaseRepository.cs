using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Repository
{
    /// <summary>
    /// Base Interface Repository 
    /// </summary>
    /// <typeparam name="T">Đối tượng thực thi base</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách của đối tượng
        /// </summary>
        /// <returns>Danh sách thông tin của đối tượng T</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Lấy toàn bộ danh sách của đối tượng hien thi trong home
        /// </summary>
        /// <returns>Danh sách thông tin của đối tượng T</returns>
        Task<IEnumerable<T>> GetDataHome();
        /// <summary>
        /// Lấy toàn bộ danh sách của đối tượng hien thi hot
        /// </summary>
        /// <returns>Danh sách thông tin của đối tượng T</returns>
        Task<IEnumerable<T>> GetDataHot();

        /// <summary>
        /// Lấy thông tin đối tượng theo ID 
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <returns>Thông tin của đối tượng T</returns>
        Task<T> GetById(Guid entityId);

        /// <summary>
        /// Thêm bản ghi 
        /// Số bản ghi được thêm
        /// </summary>
        /// <param name="entity">Đối tượng entity</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        Task<int> Insert(T entity);

        /// <summary>
        /// Sửa thông tin
        /// Sô bản ghi bị thay đổi
        /// </summary>
        /// <param name="entity">Đối tượng entity</param>
        /// <returns>Số bản ghi bị thay đổi</returns>
        /// 
        Task<int> Update(T entity);

        /// <summary>
        /// Số bản ghi được xóa
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Số bản ghi được xóa</returns>
        Task<int> Delete(Guid entityId);


        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<Pagging<T>> GetPaggingAsync(Filter filter, int sortStatus = (int)SortStatus.None, string fieldSort = "");
        #endregion
    }
}
