using System;
using System.Collections.Generic;
using System.Text;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository) : base(productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
    }
}
