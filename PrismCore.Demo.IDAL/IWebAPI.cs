using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Demo.IDAL
{
    public interface IWebAPI
    {
        HttpClient ApiClient { get; }

        Task<string> GetDatas(string uri);

        Task<TEntityOut> SignIn<TEntityIn, TEntityOut>(string uri, TEntityIn obj)
            where TEntityIn : class
            where TEntityOut : class;
    }
}
