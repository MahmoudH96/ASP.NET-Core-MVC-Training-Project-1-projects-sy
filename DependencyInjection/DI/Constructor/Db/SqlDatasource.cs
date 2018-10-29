using DependencyInjection.DI.Constructor.Interfaces;
using System.Collections.Generic;

namespace DependencyInjection.DI.Constructor.Db
{
    public class SqlDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from sql" };
        }
    }
}
