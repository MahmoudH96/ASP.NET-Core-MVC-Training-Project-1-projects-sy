using DependencyInjection.DI.InterfaceInjection.Interfaces;

namespace DependencyInjection.DI.InterfaceInjection
{
    public class App : IInjectable
    {
        public IDatasource Datasource { get; private set; }

        public void Run()
        {
            Datasource.GetData();
        }

        public void InjectDatasource(IDatasource datasource)
        {
            Datasource = datasource;
        }
    }
}
