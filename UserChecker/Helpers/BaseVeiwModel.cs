using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserChecker
{
    public class BaseVeiwModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Set<T>(ref T proprerty, T value, [CallerMemberName] String propertyName = "")
        {
            proprerty = value;
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}