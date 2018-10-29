using DependencyInjection.DI.ServiceLocatorPattern.Interfaces;

namespace DependencyInjection.DI.ServiceLocatorPattern
{
    public class App
    {
        public IDatasource Datasource { get; }

        public App(ILocator locator)
        {
            Datasource = locator.GetJsonDatasource();
        }
        public void Run()
        {
            Datasource.GetData();
        }
    }
}
