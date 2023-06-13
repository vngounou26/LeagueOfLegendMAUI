using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVM_Toolkit.Helpers
{
    public class ReadOnlyObservableDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>, INotifyPropertyChanged where TKey : notnull
    {
        private event PropertyChangedEventHandler? _propertyChanged;

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        public ReadOnlyObservableDictionary(ObservableDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
