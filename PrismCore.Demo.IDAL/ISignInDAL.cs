using PrismCore.Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IDAL
{
    public interface ISignInDAL
    {
        Task<UserEntity> SingIn(string uri, UserSignInEntity user);
    }
}
