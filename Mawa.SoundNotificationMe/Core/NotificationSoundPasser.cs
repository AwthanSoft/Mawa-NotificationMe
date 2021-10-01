using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mawa.SoundNotificationMe
{
    public static class NotificationSoundPasser //: IMessageShowerApp
    {
        private static NotificationSoundAppControlCore _instance;
        internal static NotificationSoundAppControlCore instance
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

        public static void GeneralNotify()
        {
            instance?.GeneralNotify();
        }
    }
}
