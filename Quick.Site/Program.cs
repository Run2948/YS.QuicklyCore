using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using Quick.EFCore;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Quick.Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();
            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);
                }
                logger.Info("开始记录程序执行信息：");
                host.Run();
            }
            catch (Exception e)
            {
                //NLog: catch setup errors
                logger.Error(e, "程序发生错误：" + e.Message);
                throw e;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //如果不配置下面这条信息，会导致无法直接访问//当然不用下面这个可以用Nginx来配置
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .UseNLog()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                });
    }
}
