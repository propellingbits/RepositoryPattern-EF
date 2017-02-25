using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;


namespace RepositoriesTest
{
    public class UnityBootStrapper : BootStrapper
    {
        public UnityBootStrapper() : base() { }


        protected override IServiceLocator CreateServiceLocator()
        {
            UnityContainer container = new UnityContainer();
            RegisterTypeMappings(container);
            return new UnityServiceLocator(container);
        }

        private void RegisterTypeMappings(UnityContainer unityContainer)
        {
            //perform initialization of the container and register mappings here.

            UnityConfigurationSection unityConfigurationSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            unityConfigurationSection.Configure(unityContainer);

            //unityContainer.RegisterType<EntityRepository<System.Data.Objects.ObjectContext>>("Context", new ResolvedParameter<System.Data.Objects.ObjectContext>("Context"));

            //Set the service locator 
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

        }
    }
}