using Mawa.NotificationMe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Mawa.NotificationMe.Controllers
{
    public class NotificationModel_ListCtrl : IDisposable, INotifyPropertyChanged
    {
        #region initial
        //readonly CurrencyConverterAppControl appCtrl;
        public NotificationModel_ListCtrl()
        {
            pre_refresh_Dic();
        }

        #endregion

        #region Dic
        internal Dictionary<string, NotificationModelCore> Models_dic { private set; get; }
        public NotificationModelCore[] Models_Core
        {
            get
            {
                return Models_dic.Values.ToArray();
            }
        }
        public int ModelsCount => Models_dic.Count();

        void pre_refresh_Dic()
        {
            Models_dic = new Dictionary<string, NotificationModelCore>();
        }
        void Models_Changed()
        {
            OnPropertyChanged(nameof(ModelsCount));
            OnPropertyChanged(nameof(Models_Core));
            OnPropertyChanged(nameof(Models_GeneralText));
        }

        #endregion

        #region Operation

        public void Add_NotificationModel(NotificationModelCore model)
        {
            Models_dic[model.NotifyCode] = model;
            Models_Changed();
        }
        public void Remove_NotificationModel(NotificationModelCore model)
        {
            Remove_NotificationModel(model.NotifyCode);
        }
        public void Remove_NotificationModel(string NotifyCode, bool throwIfNotExist = false)
        {
            if (Models_dic.ContainsKey(NotifyCode))
            {
                Models_dic.Remove(NotifyCode);
            }
            else
            {
                if(throwIfNotExist)
                    throw new Exception();
            }
            Models_Changed();
        }

        #endregion


        #region GeneralText

        public GeneralTextNotificationModel[] Models_GeneralText
        {
            get
            {
                return Models_dic.Values
                    .Where(b => b.NotificationType == NotificationModelType.NotificationModelTypeEnum.GeneralText)
                    .Select<NotificationModelCore, GeneralTextNotificationModel>(b => b as GeneralTextNotificationModel)
                    .ToArray();
            }
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
            Models_dic.Clear();


            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~NotificationModel_ListCtrl()
        {
            Dispose(false);
        }

        #endregion
    }
}
