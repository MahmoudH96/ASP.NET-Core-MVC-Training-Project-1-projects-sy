using System.Collections.Generic;

namespace DependencyInjection.DI.SetterProperty.Interfaces
{
    public interface IDatasource
    {
        IEnumerable<object> GetData();
    }
}
