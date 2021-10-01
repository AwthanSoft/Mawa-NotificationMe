using System;
using System.Collections.Generic;

namespace Mawa.NotificationMe
{
    public class NotificationModelType
    {
        public const string unknown = "Unknown";

        public const string general = "General";
        public const string general_text = "GeneralText";

        //public const string other = "Other";


        public enum NotificationModelTypeEnum
        {
            Unknown,

            General,
            GeneralText,

            //Other
        }

        public static NotificationModelTypeEnum str_To_enum(string str)
        {
            NotificationModelTypeEnum temp_val = NotificationModelTypeEnum.Unknown;
            if (str == null)
            {
                throw new Exception("is null");
            }

            switch (str)
            {
                case NotificationModelType.unknown:
                    {
                        temp_val = NotificationModelTypeEnum.Unknown;
                        break;
                    }

                case NotificationModelType.general:
                    {
                        temp_val = NotificationModelTypeEnum.General;
                        break;
                    }

                case NotificationModelType.general_text:
                    {
                        temp_val = NotificationModelTypeEnum.GeneralText;
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

        public static Dictionary<string, NotificationModelTypeEnum> getDic
        {
            get
            {
                return new Dictionary<string, NotificationModelTypeEnum>()
                {
                    {unknown , NotificationModelTypeEnum.Unknown },

                    {general , NotificationModelTypeEnum.General },
                    {general_text , NotificationModelTypeEnum.GeneralText },
                };
            }
        }

    }
}
