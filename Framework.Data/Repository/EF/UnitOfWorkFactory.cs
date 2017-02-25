using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.ServiceLocation;

namespace Framework.Data.Repository.EF
{
    /// <summary>
    /// UnitOfWork Factory Implementation
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork IUnitOfWorkFactory.GetUnitOfWork()
        {
            return ServiceLocator.Current.GetInstance<IUnitOfWork>("UnitOfWork");
        }
    }
}
