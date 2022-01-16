using PrismCore.Demo.Entity;
using PrismCore.Demo.IBLL;
using PrismCore.Demo.IDAL;
using System;
using System.Threading.Tasks;

namespace PrismCore.Demo.BLL
{
    public class LoginBLL : ILoginBLL
    {
        private readonly ILoginDAL _loginDAL;

        public LoginBLL(ILoginDAL loginDAL)
        {
            this._loginDAL = loginDAL;
        }
        public async Task<bool> Login(string username, string password)
        {
            var loginStr = _loginDAL.Login(username, password).GetAwaiter().GetResult();

            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(loginStr);

            if (userEntity != null)
            {

                GlobalEntity.CurrentUserInfo = userEntity;
                return true;
            }

            return false;
        }

    }
}
