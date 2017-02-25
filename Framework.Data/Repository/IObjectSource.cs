
namespace Framework.Data.Repository
{
    /// <summary>
    /// Interface that return an ObjectSource
    /// </summary>
    /// <typeparam name="TObjectSource">Type parameter for the ObjectSource</typeparam>
    public interface IObjectSource<TObjectSource> where TObjectSource : class
    {
        /// <summary>
        /// Return an ObjectSource based on the name specified
        /// </summary>
        /// <returns>
        /// An ObjectSource of type <typeparamref name="TObjectSource"/>
        /// </returns>
        TObjectSource GetObjectSource();
    }
}
