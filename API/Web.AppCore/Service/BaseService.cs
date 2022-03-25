
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Enum;
using Web.AppCore.Exceptions;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region Property
        // Khai báo : khởi tạo interface BaseRepository
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Contructor
        /// <summary>
        /// Contructor
        /// </summary>
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>Danh sách thông tin đối tượng</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }
        public async Task<IEnumerable<T>> GetDataHome()
        {
            return await _baseRepository.GetDataHome();
        }
        public async Task<IEnumerable<T>> GetDataHot()
        {
            return await _baseRepository.GetDataHot();
        }
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>Thông tin đối tượng theo Id</returns>
        public async Task<T> GetById(Guid entityId)
        {
            return await _baseRepository.GetById(entityId);
        }

        
        /// <summary>
        /// Số bản ghi được thêm mới 
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns>Số bản ghi thêm được</returns>
        public async Task<int> Insert(T entity)
        {
            //await Validate(entity, false);
            // Validate dữ liệu 
            return await _baseRepository.Insert(entity); 
        }

        /// <summary>
        /// Số bản ghi được sửa đổi
        /// </summary>
        /// <param name="entity">Đối tượng sửa đổi</param>
        /// <returns>Số bản ghi được sửa</returns>
        public async Task<int> Update(T entity)
        {
            //await Validate(entity,false);
            // số bản ghi bị thay đổi 
            return await _baseRepository.Update(entity);
        }
        /// <summary>
        /// Số bản ghi được xóa bỏ 
        /// </summary>
        /// <param name="entityId">Đối tượng được xóa</param>
        /// <returns>Số bản ghi được xoass</returns>
        public async Task<int> Delete(Guid entityId)
        {
            return await _baseRepository.Delete(entityId);
        }

        public async Task<Pagging<T>> GetPaggingAsync(Filter filter, string sort)
        {
            var sortCondition = GetSortCondition(sort);
            return await _baseRepository.GetPaggingAsync(filter,(int)sortCondition.SortStatus,sortCondition.FieldSort);
        }

        /// <summary>
        /// Lấy trạng thái sắp xếp
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        protected SortCondition GetSortCondition(string sort)
        {
            var sortCondition = new SortCondition();
            if (!string.IsNullOrEmpty(sort))
            {
                sortCondition.SortStatus = sort.Split(' ')[0] != "None" ? (sort.Split(' ')[0] == "Desc" ? SortStatus.Desc : SortStatus.Asc) : SortStatus.None;
                sortCondition.FieldSort = sort.Split(' ')[1];
            }
            return sortCondition;
        }
        protected virtual void SortData(IEnumerable<T> listData, SortCondition sort)
        {
            
        }

        //private async Task Validate(T entity, bool isInsert)
        //{
        //    // Lấy các property của class
        //    var properties = typeof(T).GetProperties();
        //    // Duyệt các property của class
        //    foreach (var property in properties)
        //    {
        //        //Lấy danh sách property có set Attribute TRequired
        //        var rProperties = property.GetCustomAttributes(typeof(TRequired), true);

        //        // Khi có ít nhất 1 property có attribute required 
        //        if (rProperties.Length > 0)
        //        {
        //            // Lấy giá trị của property
        //            var propertyValue = property.GetValue(entity);
        //            //kiểm tra giá trị
        //            if (propertyValue is null || string.IsNullOrEmpty(propertyValue.ToString()))
        //            {
        //                var rPro = rProperties[0] as TRequired;
        //                //Lỗi thông báo 
        //                var msg = TConstant.MsgErrorRequired;

        //                // Khởi tại đói tượng StringBuilder
        //                var builder = new StringBuilder();
        //                // Lấy giá trị trong Resource
        //                var valueResource = new ResourceManager(rPro.ErrorResourceType).GetString(property.Name);
        //                var name = !string.IsNullOrEmpty(valueResource) ? valueResource : property.Name;
        //                builder.AppendFormat(msg, name);
                        
        //                if (property.Name.Equals(Properties.UserResource.UserName))
        //                {
        //                    throw new ClientException(new { code = (int?)CodeUser.CodeUserNameEmpty, msg = builder.ToString() });
        //                }
        //            }
        //        }
        //    }
        //    await ValidateCustom(entity, isInsert);
        //}

        /// <summary>
        /// Validate Custom dữ liệu 
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <param name="isInsert">định nghĩa api có phải là thêm hay sửa</param>
        //protected virtual Task ValidateCustom(T entity, bool isInsert)
        //{
        //    return null;
        //}
        #endregion
    }
}
