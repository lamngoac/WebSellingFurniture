using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        #region Contructor
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Methods
        public Task<Pagging<Product>> GetProductPaggingAsync(Filter filter, string sort , string categoryId, int price)
        {
            var sortCondition = GetSortCondition(sort);
            return _productRepository.GetProductPaggingAsync(filter, (int)sortCondition.SortStatus, sortCondition.FieldSort, categoryId, price);
        }

        public async Task<IEnumerable<Product>> GetProductsTopSelling(int number)
        {
            return await _productRepository.GetProductsTopSelling(number);
        }
        #endregion
    }
}
