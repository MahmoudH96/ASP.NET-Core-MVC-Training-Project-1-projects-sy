using DependencyInjection.DI.Constructor.Db;
using DependencyInjection.DI.Constructor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Constructor
{
    public class Program
    {

        static void Main(string[] args)
        {
            IDatasource datasource = new SqlDatasource();
            /**
             * We can easily switch to JSONDatasource without chaning anything inside the app
             */
            //IDatasource datasource = new JSONDatasource();
            var app = new App(datasource);
            app.Run();
        }
    }
}
