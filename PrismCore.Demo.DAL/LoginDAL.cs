using PrismCore.Demo.IDAL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrismCore.Demo.DAL
{
    public class LoginDAL : WebAPI, ILoginDAL
    {
        public Task<string> Login(string username, string password)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("username", new StringContent(username));
            contents.Add("password", new StringContent(password));

            return this.PostDatas("User", contents);
        }
    }
}
