using Mawa.Randoms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mawa.NotificationMe.Models
{
    public abstract class NotificationModelCore : IDisposable, INotifyPropertyChanged
    {
        #region Initial 

        public readonly NotificationModelType.NotificationModelTypeEnum NotificationType;
        public readonly string NotifyCode;

        public NotificationModelCore(NotificationModelType.NotificationModelTypeEnum NotificationType,string notifyCode = null)
        {
            this.NotificationType = NotificationType;
            if (notifyCode == null)
                notifyCode = RandomId.Object_Id();
            this.NotifyCode = notifyCode;

        }


        #endregion

        #region INotify fire

        public event PropertyChangedEventHandler PropertyChanged;
        //public event PropertyChangedEventHandler PropertyChanging;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

            }

            // Free any unmanaged objects here.


            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~NotificationModelCore()
        {
            Dispose(false);
        }

        #endregion
    }
}
