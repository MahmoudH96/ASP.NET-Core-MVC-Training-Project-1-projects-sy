using DependencyInjection.DI.SetterProperty.Interfaces;

namespace DependencyInjection.DI.SetterProperty
{
    public class App
    {
        public IDatasource Datasource { get; private set; }

        public void Run()
        {
            Datasource.GetData();
        }

        public void SetDatasource(IDatasource datasource)
        {
            Datasource = datasource;
        }
    }
}
