using DependencyInjection.DI.InterfaceInjection.Interfaces;
using System.Collections.Generic;

namespace DependencyInjection.DI.InterfaceInjection.Db
{
    public class SqlDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from sql" };
        }
    }
}
