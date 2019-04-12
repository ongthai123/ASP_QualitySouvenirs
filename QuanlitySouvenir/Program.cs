using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using QuanlitySouvenir.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace QuanlitySouvenir
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateWebHostBuilder(args).Build().Run();
    //    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //             //.UseStartup<Startup>();

    //        //Disable Https
    //             .UseKestrel(options =>
    //             {
    //                 options.Listen(IPAddress.Loopback, 8080);
    //             })
    //        .UseStartup<Startup>();
    //}
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            var host = BuildWebHost(args); //Added in Week 1

            //Added for Week 1
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SouvenirshopContext>();
                    SouvenirDbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run(); //Added for Week 1
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseKestrel(options =>
             {
                 options.Listen(IPAddress.Loopback, 8080);
             })
                .UseStartup<Startup>()
                .Build();


    }
}
