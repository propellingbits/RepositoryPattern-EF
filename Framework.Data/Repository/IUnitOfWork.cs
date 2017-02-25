using System;
using System.Diagnostics.CodeAnalysis;


namespace Framework.Data.Repository
{
    /// <summary>
    /// unit of work pattern interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Gets the object source.
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        /// <remarks>
        /// An object source provides information about the object"s persistence.
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification="Method intended.")]
        TObjectSource GetObjectSource<TObjectSource>() where TObjectSource : class;

        /// <summary>
        /// Adds the object source.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <remarks>
        /// An object source provides information about the object"s persistence.
        /// </remarks>
        void AddObjectSource<TEntity, TObjectSource>(RepositoryBase<TEntity> repository)
            where TEntity : class
            where TObjectSource : class;
    }
}