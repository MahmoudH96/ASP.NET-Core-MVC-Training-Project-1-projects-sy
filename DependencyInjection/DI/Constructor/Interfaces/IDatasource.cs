using System.Collections.Generic;

namespace DependencyInjection.DI.Constructor.Interfaces
{
    public interface IDatasource
    {
        IEnumerable<object> GetData();
    }
}
