
namespace Framework.Data.Repository
{
    /// <summary>
    /// interface for Unit Of Work Scope
    /// </summary>
    public interface IUnitOfWorkScope
    {
        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
