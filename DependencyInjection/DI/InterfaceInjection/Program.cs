using DependencyInjection.DI.InterfaceInjection.Interfaces;
using DependencyInjection.DI.InterfaceInjection.Db;

namespace DependencyInjection.DI.InterfaceInjection
{
    public class Program
    {

        static void Main(string[] args)
        {
            IDatasource datasource = new JSONDatasource();
            /**
             * We can easily switch to SqlDatasource without chaning anything inside the app
             */
            //IDatasource datasource = new SqlDatasource();
            var app = new App();
            app.InjectDatasource(datasource);
            app.Run();
        }
    }
}
