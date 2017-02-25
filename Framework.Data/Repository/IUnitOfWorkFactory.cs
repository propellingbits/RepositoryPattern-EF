
using System.Diagnostics.CodeAnalysis;
namespace Framework.Data.Repository
{
    /// <summary>
    /// interface for unit of work factory pattern
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        IUnitOfWork GetUnitOfWork();
    }
}
