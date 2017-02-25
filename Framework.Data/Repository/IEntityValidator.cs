using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Framework.Data.Repository
{
    /// <summary>
    /// Entity Validation Interface
    /// </summary>    
    public interface IEntityValidator
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        ValidationResults Validate<TEntity>(TEntity entity) where TEntity : class;
    }
}
