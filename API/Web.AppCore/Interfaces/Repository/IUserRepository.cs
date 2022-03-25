using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUserName(string userName);

    }
}
