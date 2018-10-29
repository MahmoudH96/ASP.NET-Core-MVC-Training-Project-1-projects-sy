using DependencyInjection.DI.ServiceLocatorPattern.Interfaces;
using System.Collections.Generic;

namespace DependencyInjection.DI.ServiceLocatorPattern.Db
{
    public class SqlDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from sql" };
        }
    }
}
