using System;
using System.Collections.Generic;
using System.Text;

namespace Mawa.NotificationMe.Models
{
    public class GeneralTextNotificationModel : NotificationModelCore
    {
        #region Initial 

        public string Title { set; get; }
        public string Message { set; get; }
        public string Icon { set; get; }
        public Action ClickAction { set; get; }

        public GeneralTextNotificationModel(string notifyCode = null) :base(NotificationModelType.NotificationModelTypeEnum.GeneralText , notifyCode)
        {
            
        }

        #endregion
    }
}
