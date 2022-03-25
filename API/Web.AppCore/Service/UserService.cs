using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.AppCore.Entities;
using Web.AppCore.Interfaces.Repository;
using Web.AppCore.Interfaces.Services;

namespace Web.AppCore.Service
{
    public class UserService: BaseService<User>, IUserService
    {
        IUserRepository _userRespository;
        public UserService(IUserRepository userRespository): base(userRespository)
        {
            _userRespository = userRespository;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _userRespository.GetUserByUserName(userName);
        }

        //protected override async Task ValidateCustom(User entity, bool isInsert)
        //{
        //    if (entity is User)
        //    {
        //        var user = entity as User;
        //        // xem tài khoản
        //        //var isExits = await _employeeRepository.CheckEmployeeExists(employee.EmployeeCode);

        //       msg = String.Format(Properties.EmployeeResource.MsgErrorEmployeeCodeExists, employee.EmployeeCode) };
        //        ////validate update
        //        //if (isInsert == false)
        //        //{
        //        //    //Lấy EmployeeCode by EmployeeId
        //        //    var employeeCode = await _employeeRepository.GetEmployeeCodeById(employee.EmployeeId);
        //        //    // Check trùng mã:
        //        //    if (isExits == true && employeeCode != employee.EmployeeCode)
        //        //    {
        //        //        throw new ClientException(res);
        //        //    }
        //        //}
        //        //else
        //        //{
        //        //    // Check trùng mã
        //        //    if (isExits == true)
        //        //    {
        //        //        throw new ClientException(res);
        //        //        //throw new ClientException(new { code = 1  });
        //        //    }
        //        //}
        //    }
        //}
    }
}
