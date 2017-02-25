using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.EnterpriseLibrary.Validation;



namespace Framework.Data.Repository
{
    /// <summary>
    /// Extension methods for <see cref="IRepository&lt;TEntity&gt;"/>.
    /// </summary>
    public static class IRepositoryExtensions
    {

        /// <summary>
        /// Gets the validation results.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "repository", 
            Justification="Required for extension method to work properly.")]
        public static ValidationResults GetValidationResults<TEntity>(this IRepository<TEntity> repository, TEntity entity) where TEntity : class
        {
            return Validation.Validate<TEntity>(entity);
        }
    }
}
