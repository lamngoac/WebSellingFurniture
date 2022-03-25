using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;


namespace Web.AppCore.Interfaces.Repository
{

    public interface INewsRepository : IBaseRepository<News>
    {
        Task<IEnumerable<News>> GetDataNewsProduct();
        Task<IEnumerable<News>> GetDataNewsSale();
        Task<IEnumerable<News>> GetDataNewsEvent();
    }
}
