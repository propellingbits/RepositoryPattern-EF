using System;
using Microsoft.Practices.ServiceLocation;

namespace RepositoriesTest
{
    public abstract class BootStrapper
    {
        public static IServiceLocator Locator;

        protected BootStrapper()
        {
            Locator = CreateServiceLocator();
        }

        protected abstract IServiceLocator CreateServiceLocator();
    }
}