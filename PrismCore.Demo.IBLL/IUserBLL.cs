using PrismCore.Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IBLL
{
    public interface IUserBLL
    {
        Task<List<UserEntity>> GetAll();

        Task<List<RoleEntity>> GetRolesByUserId(int userId);

        Task ResetPassword(string userId);
    }
}
