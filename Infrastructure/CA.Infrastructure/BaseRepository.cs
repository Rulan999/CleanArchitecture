using System;

namespace CA.Infrastructure
{
    public abstract class BaseRepository : IDisposable
    {
        #region Member Variables

        protected BaseDBContext _appDbContext;
        #endregion

        #region Constructors

        protected BaseRepository(BaseDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #endregion

        #region IDisposable Members

        protected bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_appDbContext != null)
                {
                    _appDbContext.Dispose();
                    _appDbContext = null;
                }
            }

            _isDisposed = true;
        }

        #endregion
    }
}
