using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns> Thông tin danh sách của đối tượng</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Lấy toàn bộ danh sách hien thi trong home
        /// </summary>
        /// <returns> Thông tin danh sách của đối tượng</returns>
        Task<IEnumerable<T>> GetDataHome();
        /// <summary>
        /// Lấy toàn bộ danh sách hien thi trong home
        /// </summary>
        /// <returns> Thông tin danh sách của đối tượng</returns>
        Task<IEnumerable<T>> GetDataHot();
        /// <summary>
        /// Lấy thông tin đối tượng theo ID 
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>Thông tin đối tượng theo Id</returns>
        Task<T> GetById(Guid entityId);

        /// <summary>
        /// Thêm bản ghi 
        /// </summary>
        /// <param name="entity">Đối tượng entity</param>
        /// <returns>Số bản ghi thêm được</returns>
        /// 
        Task<int> Insert(T entity);

        /// <summary>
        /// Sô bản ghi bị thay đổi
        /// </summary>
        /// <param name="entity">Đối tượng entity</param>
        /// <returns>Số bản ghi bị sửa đổi</returns>
        /// 
        Task<int> Update(T entity);


        /// <summary>
        /// Số bản ghi được xóa 
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>Số bản ghi được xóa</returns>
        Task<int> Delete(Guid entityId);

        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <returns></returns>
        Task<Pagging<T>> GetPaggingAsync(Filter filter, string sort="");
        #endregion
    }
}
