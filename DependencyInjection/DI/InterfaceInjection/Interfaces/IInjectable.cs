using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.InterfaceInjection.Interfaces
{
    public interface IInjectable
    {
        void InjectDatasource(IDatasource datasource);
    }
}
