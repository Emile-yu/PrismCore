using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PrismCore.Server;
using Autofac.Extensions.DependencyInjection;

namespace PrismCore.Server.FunctionalTests
{
    public class FunctionTestBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(FunctionTestBase)).Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<Startup>();

            return new TestServer(hostBuilder);
        }
    }
}
