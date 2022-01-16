using PrismCore.Demo.Entity;
using PrismCore.Demo.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.DAL
{
    public class SignInDAL : ISignInDAL
    {
        private readonly IWebAPI _webAPI;

      
        public SignInDAL(IWebAPI webAPI)
        {
            this._webAPI = webAPI;
        }

        public Task<UserEntity> SingIn(string uri, UserSignInEntity user)
        {
            return _webAPI.SignIn<UserSignInEntity, UserEntity>(uri, user);
        }
    }
}
