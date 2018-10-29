using System.Collections.Generic;

namespace DependencyInjection.DI.InterfaceInjection.Interfaces
{
    public interface IDatasource
    {
        IEnumerable<object> GetData();
    }
}
