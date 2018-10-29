using DependencyInjection.DI.ServiceLocatorPattern.Db;
using DependencyInjection.DI.ServiceLocatorPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.ServiceLocatorPattern
{
    public class Locator : ILocator
    {
        public IDatasource GetJsonDatasource()
        {
            return new JSONDatasource();
        }

        public IDatasource GetSqlDatasource()
        {
            return new SqlDatasource();
        }
    }
}
