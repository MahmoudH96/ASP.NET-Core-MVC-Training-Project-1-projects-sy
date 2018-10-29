using DependencyInjection.DI.SetterProperty.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.SetterProperty.Db
{
    public class JSONDatasource : IDatasource
    {
        public IEnumerable<object> GetData()
        {
            return new List<string>() { "data from json" };
        }
    }
}
