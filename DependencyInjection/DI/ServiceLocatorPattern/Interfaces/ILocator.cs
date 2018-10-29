using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.ServiceLocatorPattern.Interfaces
{
    public interface ILocator
    {
        IDatasource GetSqlDatasource();
        IDatasource GetJsonDatasource();
    }
}
