using System;
using Microsoft.Practices.Unity;
using Framework.Data.Repository;
using Framework.Data.Repository.EF;
using ChildSupport.Domain;
using ChildSupport.DataModel;

namespace ChildSupport.Dal
{
    /// <summary>
    /// This class registers the repositories in the Unity container.
    /// </summary>
    public static class RepositoriesInitializer
    {
        /// <summary>
        /// Registers singleton instances of the repositories.
        /// </summary>
        public static void RegisterInstances(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IRepository<Employee>, EntityRepository<Employee, AdventureWorks2008R2Entities>>(new ContainerControlledLifetimeManager(), new InjectionConstructor());
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>(new ContainerControlledLifetimeManager());           
        }
    }
}