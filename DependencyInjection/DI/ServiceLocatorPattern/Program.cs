using DependencyInjection.DI.ServiceLocatorPattern.Interfaces;
using DependencyInjection.DI.ServiceLocatorPattern.Db;

namespace DependencyInjection.DI.ServiceLocatorPattern
{
    public class Program
    {

        static void Main(string[] args)
        {
            ILocator locator = new Locator();
            var app = new App(locator);
            app.Run();
        }
    }
}
