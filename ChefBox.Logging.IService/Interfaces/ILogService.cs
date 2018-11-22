using ChefBox.Logging.Dto.Enums;
using ChefBox.Logging.Dto.Errors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ChefBox.Logging.IService.Interfaces
{
    public interface ILogService
    {
        void InitialConfigure();
        IWebHostBuilder ConfigureWebHost(IWebHostBuilder webHost);
        void ConfigureCloudLog
            (IApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory);
        void LogMessage(string message, LogType logType);
        void LogDomainError(DomainErrorDto domainErrorDto);
        void LogHttpError(HttpErrorDto httpErrorDto);
        void CloseAndFlush();
    }
}
