using CommonAppCore.Locks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mawa.SoundNotificationMe
{
    public abstract class NotificationSoundAppControlCore : INotificationSoundApp, IDisposable
    {
        #region Initail

        public NotificationSoundAppControlCore()
        {
            pre_refresh();

            NotificationSoundPasser.instance = this;
        }
        private void pre_refresh()
        {
            objectLock = new ObjectLock();
        }

        // For Lock
        #region Lock Base Properties
        private ObjectLock objectLock;

        protected void open_lock()
        {
            objectLock.open_lock();
        }
        protected void close_lock()
        {
            objectLock.close_lock();
        }

        #endregion

        #endregion

        #region Shower

        public virtual void GeneralNotify()
        {
            open_lock();
            _GeneralNotify();
            close_lock();
        }
        protected abstract void _GeneralNotify();

        #endregion

        #region Dispose

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                this?.Dispose_FreeManaged();
            }

            // Free any unmanaged objects here.
            this?.Dispose_FreeUnManaged();


            _disposed = true;
        }

        protected abstract void Dispose_FreeManaged();
        protected abstract void Dispose_FreeUnManaged();
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       

        ~NotificationSoundAppControlCore()
        {
            Dispose(false);
        }
       

        #endregion
    }
}
