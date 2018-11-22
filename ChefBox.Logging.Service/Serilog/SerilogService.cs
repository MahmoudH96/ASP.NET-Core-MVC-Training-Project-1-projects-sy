using ChefBox.Logging.Dto.Enums;
using ChefBox.Logging.Dto.Errors;
using ChefBox.Logging.IService.Interfaces;
using ChefBox.Logging.Service.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SumoLogic;

namespace ChefBox.Logging.Service.Serilog
{
    public class SerilogService : ILogService
    {
        private const string SumoLogicUrl = "https://collectors.de.sumologic.com/receiver/v1/http/ZaVnC4dhaV0UzHOBcjpSfcwzE4D1IWc9jVamTjfehVPAYVk1W6QW9Fve6z772dMDqK8TRtnrsMpKOfLCVPhtt5qp0g-_cfIi9WKcP7zgrSPC2bCdjBQT2w==";
        public void InitialConfigure()
        {
            Log.Logger = new LoggerConfiguration()
                           .MinimumLevel.Debug()
                           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                           .Enrich.FromLogContext()
                           .WriteTo.Console()
                           .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                           .WriteTo.SumoLogic(SumoLogicUrl)
                           .CreateLogger();
        }
        public IWebHostBuilder ConfigureWebHost(IWebHostBuilder webHost)
        {
            return webHost.UseSerilog();
        }

        public void ConfigureCloudLog(IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            applicationLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
        }

        public void LogDomainError(DomainErrorDto domainErrorDto)
        {
            LogMessage(domainErrorDto.ToLogJson(), LogType.Error);
        }

        public void LogHttpError(HttpErrorDto httpErrorDto)
        {
            LogMessage(httpErrorDto.ToLogJson(), LogType.Error);
        }

        public void LogMessage(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.Info:
                    {
                        Log.Information(message);
                        break;
                    }
                case LogType.Warn:
                    {
                        Log.Warning(message);
                        break;
                    }
                case LogType.Error:
                    {
                        Log.Error(message);
                        break;
                    }
                case LogType.Fatal:
                    {
                        Log.Fatal(message);
                        break;
                    }
            }
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
