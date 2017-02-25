
namespace Framework.Data.Repository
{
    /// <summary>
    /// scope options enum
    /// </summary>
    public enum ScopeOption
    {
        /// <summary>
        /// No scope at all.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// To Save all the changes when the Save method is invoked.
        /// </summary>
        SaveAllWhenScopeEnds = 1,

    }
}
