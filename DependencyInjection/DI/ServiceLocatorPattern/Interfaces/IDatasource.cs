using System.Collections.Generic;

namespace DependencyInjection.DI.ServiceLocatorPattern.Interfaces
{
    public interface IDatasource
    {
        IEnumerable<object> GetData();
    }
}
