using System;
using System.Collections.Generic;

namespace Mawa.NotificationMe
{
    public class NotificationReadingState
    {
        public const string unknown = "Unknown";

        public const string general = "General";
        public const string to_it = "ToIt";

        //public const string other = "Other";


        public enum NotificationReadingStateEnum
        {
            Unknown,

            General,
            ToIt,

            //Other
        }

        public static NotificationReadingStateEnum str_To_enum(string str)
        {
            NotificationReadingStateEnum temp_val = NotificationReadingStateEnum.Unknown;
            if (str == null)
            {
                throw new Exception("is null");
            }

            switch (str)
            {
                case NotificationReadingState.unknown:
                    {
                        temp_val = NotificationReadingStateEnum.Unknown;
                        break;
                    }

                case NotificationReadingState.general:
                    {
                        temp_val = NotificationReadingStateEnum.General;
                        break;
                    }

                case NotificationReadingState.to_it:
                    {
                        temp_val = NotificationReadingStateEnum.ToIt;
                        break;
                    }

                default:
                    {
                        throw new Exception("No support");
                        //return null;
                        //break;
                    }
            }
            return temp_val;
        }

        public static Dictionary<string, NotificationReadingStateEnum> getDic
        {
            get
            {
                return new Dictionary<string, NotificationReadingStateEnum>()
                {
                    {unknown , NotificationReadingStateEnum.Unknown },

                    {general , NotificationReadingStateEnum.General },
                    {to_it , NotificationReadingStateEnum.ToIt },
                };
            }
        }

    }
}
