using PrismCore.Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IBLL
{
    public interface ISignInBLL
    {
        string Uri { get; }
        Task<UserEntity> SingIn(UserSignInEntity user);
    }
}
