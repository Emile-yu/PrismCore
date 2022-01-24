using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismCore.Server.FunctionalTests
{
    public class TestHostBuild
    {

        public static HttpClient GetTestClient 
        {
            get
            {
                IHost host = CreateAndRun().GetAwaiter().GetResult();
                _host = host;
                return _host.GetTestClient();
            } 
        } 

        private static IHost _host;

        private static Task<IHost> CreateAndRun() => CreateHostBuilder().StartAsync();

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseTestServer(); //关键是多了这一行建立TestServer
                })
               
                // 使用 auto fac 代替默认的 IOC 容器 
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
