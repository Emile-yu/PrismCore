using PrismCore.Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IDAL
{
    public interface IUserDAL
    {
        //获取JsonResult
        Task<string> GetAll();
        Task<string> GetRolesByUserId(int userId);

        Task ResetPassword(string userId);
    }
}
