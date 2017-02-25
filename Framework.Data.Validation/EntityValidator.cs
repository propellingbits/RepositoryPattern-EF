using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Framework.Data.Repository;


namespace Framework.Data.Validation
{
    /// <summary>
    /// EntityValidator.
    /// </summary>
    public class EntityValidator : IEntityValidator
    {

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public ValidationResults  Validate<TEntity>(TEntity entity) where TEntity : class
        {
            ValidatorFactory _valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<TEntity> _entityValidator = _valFactory.CreateValidator<TEntity>();
          
            ValidationResults results = _entityValidator.Validate(entity);
            // Note that the results are already localized to the current culture.
            return results;
        }
    }
}