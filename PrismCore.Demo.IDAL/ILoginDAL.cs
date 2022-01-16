using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IDAL
{
    public interface ILoginDAL
    {
        Task<string> Login(string username, string password);
    }
}
