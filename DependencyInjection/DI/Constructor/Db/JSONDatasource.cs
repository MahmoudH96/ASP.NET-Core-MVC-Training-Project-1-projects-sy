using DependencyInjection.DI.Constructor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Constructor.Db
{
    public class JSONDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from json" };
        }
    }
}
