using System;
using System.Threading;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics.CodeAnalysis;
using System.Data.Objects;
using Framework.Data.Repository.EF;


namespace Framework.Data.Repository
{
    /// <summary>
    /// Unit of WorkScope facade class
    /// </summary>
    public
#if RELEASE
    sealed
#endif
    class UnitOfWorkScope : IUnitOfWorkScope, IDisposable
    {
        [ThreadStatic] // otherwise this variable will get shared at app level
        private static UnitOfWorkScope _currentScope;
        private UnitOfWorkBase _unitOfWork;
        [ThreadStatic]
        private static UnitOfWorkBase _scopedUnitOfWork;
        private ScopeOption _scopeOption = ScopeOption.None;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkScope"/> class.
        /// </summary>
        public UnitOfWorkScope() : this(ScopeOption.SaveAllWhenScopeEnds) { }  //default option with SaveAllWhenScopeEnds

        //user to customize the scope option through this constructor.

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkScope"/> class.
        /// </summary>
        /// <param name="scopeOption">The scope options.</param>
        public UnitOfWorkScope(ScopeOption scopeOption)
        {
            if (_currentScope != null && !_isDisposed)
                throw new InvalidOperationException("UnitOfWorkScope instances cannot be nested.");
         
            _scopeOption = scopeOption;
            _isDisposed = false;
            
            // Unitofworkscope will not span across requests so we are good here.
            Thread.BeginThreadAffinity();
            _currentScope = this;
            _unitOfWork = (UnitOfWorkBase)(ServiceLocator.Current.GetInstance<IUnitOfWorkFactory>("UnitOfWorkFactory").GetUnitOfWork());

            /*_currentScope = this;
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>("UnitOfWork");*/
        }

        /// <summary>
        /// Adds the object source.
        /// </summary>
        /// <remarks>
        /// Though this member is static, it calls a method on a member that is thread static (i.e. has thread affinity).  
        /// Thus it does not act as a typical static method.
        /// </remarks>
        /// <param name="repository">The object source.</param>
        public static void AddObjectSource<TEntity, TObjectSource>(RepositoryBase<TEntity> repository) 
            where TEntity : class 
            where TObjectSource : class
        {
            _currentScope._unitOfWork.AddObjectSource<TEntity, TObjectSource>(repository);
        }

        /// <summary>
        /// Gets the current object source.
        /// </summary>
        /// <typeparam name="TObjectSource">The type of the object source.</typeparam>
        /// <returns></returns>
        public static TObjectSource GetCurrentObjectSource<TObjectSource>() where TObjectSource : class
        {
            if (_currentScope != null)
            {
                return _currentScope._unitOfWork.GetObjectSource<TObjectSource>();
            }
            else
            {
                if (_scopedUnitOfWork == null)
                    _scopedUnitOfWork = (UnitOfWorkBase)(ServiceLocator.Current.GetInstance<IUnitOfWorkFactory>("UnitOfWorkFactory").GetUnitOfWork());
                return _scopedUnitOfWork.GetObjectSource<TObjectSource>();
            }
        }

        /// <summary>
        /// Gets the scope options.
        /// </summary>
        /// <value>The scope options.</value>
        public static ScopeOption ScopeOption
        {
            get
            {
                if (_currentScope != null)
                    return _currentScope._scopeOption;
                else
                    return ScopeOption.None;
            }

        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            int count = 0;

            if (_scopeOption == ScopeOption.SaveAllWhenScopeEnds)
            {
                count = _unitOfWork.Commit();

            }

            return count;
        }

        #region IDisposable Members

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {

            //The dispose method will be called once the the program execution exist the UnitOfWorkScope's scope.
            if (disposing)
            {


            }

            if (!_isDisposed)
            {
                //Clear the value of the thread static member
                _currentScope = null;

                //Tell the managed host we are done with it.
                Thread.EndThreadAffinity();
                //Release the resources for the unit of work instance.
                _unitOfWork.Dispose();
                _isDisposed = true;

            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="UnitOfWorkScope"/> is reclaimed by garbage collection.
        /// </summary>
        ~UnitOfWorkScope()
        {
            Dispose(false);
        }
        #endregion
    }
}