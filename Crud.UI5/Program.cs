using Crud.Infra;
using LinqToDB.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Crud.UI5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //DataConnection.DefaultSettings = new MySettings();
            DataConnection.DefaultSettings = new MySettings();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
