using Mawa.NotificationMe.Controllers;
using Mawa.NotificationMe.Models;
using Mawa.Lock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mawa.NotificationMe
{
    public abstract class NotificationAppControlCore : IDisposable, INotificationApp
    {
        #region Initail
        public NotificationAppControlCore()
        {
            pre_refresh();

            NotificationPasser.instance = this;
        }
        private void pre_refresh()
        {
            objectLock = new ObjectLock();
            pre_refresh_ListCtrl();

        }

        // For Lock
        #region Lock Base Properties
        private ObjectLock objectLock;

        protected void open_Lock()
        {
            objectLock.open_lock();
        }
        protected void close_Lock()
        {
            objectLock.close_lock();
        }

        #endregion

        #endregion

        #region ListCtrl
        public NotificationModel_ListCtrl notificationModel_ListCtrl { private set; get; }
        void pre_refresh_ListCtrl()
        {
            notificationModel_ListCtrl = new NotificationModel_ListCtrl();
        }

        #endregion

        #region Add

        public void AddNotification(string title, string Message,string icon = null, string NotifyCode = null)
        {
            open_Lock();
            _AddNotification(
                title,
                Message,
                icon,
                NotifyCode);
            close_Lock();
        }
        protected void _AddNotification(string title, string Message, string icon, string NotifyCode)
        {
            notificationModel_ListCtrl.Add_NotificationModel(
                new GeneralTextNotificationModel(NotifyCode)
                {
                    Title = title,
                    Message = Message,
                    Icon = icon
                });
        }

        public void AddNotification(string title, string Message, Action ClickAction, string icon = null, string NotifyCode = null)
        {
            open_Lock();
            _AddNotification(
                title,
                Message,
                ClickAction,
                icon,
                NotifyCode);
            close_Lock();
        }
        void _AddNotification(string title, string Message, Action ClickAction , string icon ,string NotifyCode)
        {
            notificationModel_ListCtrl.Add_NotificationModel(
                new GeneralTextNotificationModel(NotifyCode)
                {
                    Title = title,
                    Message = Message,
                    Icon = icon,
                    ClickAction = ClickAction
                });
        }

        #endregion

        #region Remove

        public void RemoveNotification(NotificationModelCore notificationModelCore)
        {
            open_Lock();
            _RemoveNotification(notificationModelCore);
            close_Lock();
        }
        protected void _RemoveNotification(NotificationModelCore notificationModelCore)
        {
            notificationModel_ListCtrl.Remove_NotificationModel(notificationModelCore);
        }
        //RemoveNotification_By_NotifyCode
        public void RemoveNotification_By_NotifyCode(string NotifyCode)
        {
            open_Lock();
            _RemoveNotification_By_NotifyCode(NotifyCode);
            close_Lock();
        }
        protected void _RemoveNotification_By_NotifyCode(string NotifyCode)
        {
            notificationModel_ListCtrl.Remove_NotificationModel(NotifyCode);
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
        ~NotificationAppControlCore()
        {
            Dispose(false);
        }
       

        #endregion
    }
}
