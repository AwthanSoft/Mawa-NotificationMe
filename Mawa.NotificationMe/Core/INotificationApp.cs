using Mawa.NotificationMe.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mawa.NotificationMe
{
    public interface INotificationApp
    {
        #region Add
        void AddNotification(string title, string Message, string icon = null, string NotifyCode = null);
        void AddNotification(string title, string Message, Action ClickAction, string icon = null, string NotifyCode = null);

        #endregion

        #region Remove

        void RemoveNotification(NotificationModelCore notificationModelCore);
        void RemoveNotification_By_NotifyCode(string NotifyCode);
        #endregion
    }
}
