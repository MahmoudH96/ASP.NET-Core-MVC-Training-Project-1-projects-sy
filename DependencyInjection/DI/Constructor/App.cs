using DependencyInjection.DI.Constructor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Constructor
{
    public class App
    {
        public IDatasource Datasource { get; }
        public App(IDatasource datasource)
        {
            Datasource = datasource;
        }
        public void Run()
        {
            Datasource.GetData();
        }
    }
}
