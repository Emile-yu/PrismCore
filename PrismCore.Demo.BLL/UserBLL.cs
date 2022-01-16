using PrismCore.Demo.Entity;
using PrismCore.Demo.IBLL;
using PrismCore.Demo.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;

        public UserBLL(IUserDAL userDAL)
        {
            this._userDAL = userDAL;
        }
        public async Task<List<UserEntity>> GetAll()
        {
            string result =await _userDAL.GetAll();
            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(result);
        }

        public async Task<List<RoleEntity>> GetRolesByUserId(int userId)
        {
            string result = await _userDAL.GetRolesByUserId(userId);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(result);
        }

        public Task ResetPassword(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
