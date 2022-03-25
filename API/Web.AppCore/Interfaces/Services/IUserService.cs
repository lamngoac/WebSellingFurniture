using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;

namespace Web.AppCore.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetUserByUserName(string userName);
    }
}
