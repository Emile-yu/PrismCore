using System;
using System.Threading.Tasks;
using Xunit;

namespace PrismCore.Server.FunctionalTests
{
    public class WebApiTest : FunctionTestBase
    {
        //[Fact]
        //public async Task Test1()
        //{
        //    using (var server = CreateServer())
        //    {
        //        var reponse = await server.CreateClient().GetAsync("/WeatherForecastController/Get");

        //        reponse.EnsureSuccessStatusCode();
        //    }
        //}
        [Fact]
        public async Task Test2()
        {
            using (var server = TestHostBuild.GetTestClient)
            {
                var reponse = await server.GetAsync("/WeatherForecast");

                reponse.EnsureSuccessStatusCode();
                
            }
        }
    }
}
