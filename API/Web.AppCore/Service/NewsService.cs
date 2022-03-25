using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;


namespace Web.AppCore.Service
{
    public class NewsService : BaseService<News>, INewsService
    {
        INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository) : base(newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<IEnumerable<News>> GetDataNewsProduct()
        {
            return await _newsRepository.GetDataNewsProduct();
        }
        public async Task<IEnumerable<News>> GetDataNewsSale()
        {
            return await _newsRepository.GetDataNewsSale();
        }
        public async Task<IEnumerable<News>> GetDataNewsEvent()
        {
            return await _newsRepository.GetDataNewsEvent();
        }
    }
}
