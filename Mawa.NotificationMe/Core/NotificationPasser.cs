using Mawa.NotificationMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mawa.NotificationMe
{
    public static class NotificationPasser //: INotificationApp
    {
        private static NotificationAppControlCore _instance;
        internal static NotificationAppControlCore instance
        {
             set
            {
                if (_instance == null)
                    _instance = value;
                else
                    throw new Exception();
            }
            //get => _instance;
            // as temp for test .?
            get
            {
                if (_instance == null)
                    throw new Exception();
                return _instance;
            }
        }

        public static void AddNotification(string title, string Message, string icon = null, string NotifyCode = null)
        {
            instance?.AddNotification(
                title,
                Message,
                icon,
                NotifyCode);
        }
        public static void AddNotification(string title, string Message, Action ClickAction, string icon = null, string NotifyCode = null)
        {
            instance?.AddNotification(
                title,
                Message,
                ClickAction,
                icon,
                NotifyCode);
        }
        
        public static void RemoveNotification(NotificationModelCore notificationModelCore)
        {
            instance?.RemoveNotification(notificationModelCore);
        }
        public static void RemoveNotification_By_NotifyCode(string NotifyCode)
        {
            instance?.RemoveNotification_By_NotifyCode(NotifyCode);
        }
    }
}
