using PrismCore.Demo.Entity;
using PrismCore.Demo.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.DAL
{
    public class UserDAL : WebAPI, IUserDAL
    {
        public Task<string> GetAll()
        {
            return this.GetDatas("user/all");
        }

        public Task<string> GetRolesByUserId(int userId)
        {
            return this.GetDatas($"user/roles/{userId}");
        }

        public Task ResetPassword(string userId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId));

            return this.PostDatas("user/resetpwd", param);
        }
    }
}
