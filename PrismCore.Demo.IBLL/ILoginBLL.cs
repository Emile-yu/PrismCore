using System;
using System.Threading.Tasks;

namespace PrismCore.Demo.IBLL
{
    public interface ILoginBLL
    {
        Task<bool> Login(string username, string password);
    }
}
