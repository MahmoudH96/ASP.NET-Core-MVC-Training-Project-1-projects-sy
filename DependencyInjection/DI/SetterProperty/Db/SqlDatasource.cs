using DependencyInjection.DI.SetterProperty.Interfaces;
using System.Collections.Generic;

namespace DependencyInjection.DI.SetterProperty.Db
{
    public class SqlDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from sql" };
        }
    }
}
