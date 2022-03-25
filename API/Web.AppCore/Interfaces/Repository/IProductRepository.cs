using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// Lấy danh sách sản phẩm theo điều kiện lọc
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortStatus"></param>
        /// <param name="fieldSort"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Pagging<Product>> GetProductPaggingAsync(Filter filter, int sortStatus, string fieldSort, string categoryId,int price);

        Task<IEnumerable<Product>> GetProductsTopSelling(int number);
    }
}
