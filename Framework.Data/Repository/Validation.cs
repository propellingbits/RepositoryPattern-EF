using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Framework.Data.Repository
{

    /// <summary>
    /// Validation class.
    /// </summary>
    /// <remarks>
    /// Works in much the same way as the EntLib Validation class.
    /// </remarks>
    public static class Validation
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <remarks>This interface needs to be registered in the Container before using it.</remarks>
        public static ValidationResults Validate<TEntity>(TEntity entity) where TEntity : class
        {
            IEntityValidator entityValidator = ServiceLocator.Current.GetInstance<IEntityValidator>(); 
            return entityValidator.Validate(entity);
        }
    }
}
