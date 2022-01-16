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
    public class SignInBLL : ISignInBLL
    {
        private static string _uri = "User/SignInEntity";

        private readonly ISignInDAL _signDAL;

        public string Uri { get => _uri; }

        public SignInBLL(ISignInDAL signDAL)
        {
            this._signDAL = signDAL;
        }

        public Task<UserEntity> SingIn(UserSignInEntity user)
        {
            return _signDAL.SingIn(_uri, user);
        }
    }
}
