using ChefBox.Logging.IService.Interfaces;
using ChefBox.Logging.Service.Serilog;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SumoLogic;
using System;
using System.Diagnostics;

namespace ChefBox.AdminUI
{
    public class Program
    {
        private static ILogService LogService { set; get; }
        public static int Main(string[] args)
        {
            LogService = new SerilogService();
            LogService.InitialConfigure();

            try
            {
                LogService.LogMessage("Start chefbox", Logging.Dto.Enums.LogType.Info);
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                LogService.LogMessage($"Error occurs in chefbox{ex.ToString()}", Logging.Dto.Enums.LogType.Fatal);
                return 1;
            }
            finally
            {
                LogService.CloseAndFlush();
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var webHost = WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>();
            if (LogService != null)
            {
                return LogService.ConfigureWebHost(webHost);
            }
            return webHost;
        }

    }
}
