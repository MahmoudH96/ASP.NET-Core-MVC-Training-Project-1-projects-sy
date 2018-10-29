using DependencyInjection.DI.SetterProperty.Interfaces;
using DependencyInjection.DI.SetterProperty.Db;

namespace DependencyInjection.DI.SetterProperty
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
            app.SetDatasource(datasource);
            app.Run();
        }
    }
}
