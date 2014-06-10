using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PakaPakaCalc.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void SetProperty<U>(
            ref U backingStore, U value,
            string propertyName,
            Action onChanged = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            if (onChanged != null)
                {
                    onChanged();
                }

            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

//        public event PropertyChangedEventHandler PropertyChanged;
//        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
//        {
//            if (PropertyChanged != null)
//            {
//                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//            }
//        }
    }
}

