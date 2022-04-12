using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CicekSepeti.Data.Context;

namespace CicekSepeti.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            GenerateMockData();
            
            host.Run();
        }

        private static void GenerateMockData()
        {
            MockData mockData = new MockData();
            mockData.ProductData();
            mockData.CartData();
            mockData.StockData();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
