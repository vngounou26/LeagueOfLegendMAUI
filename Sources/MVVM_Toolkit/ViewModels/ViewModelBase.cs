using CommunityToolkit.Mvvm.ComponentModel;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Toolkit.ViewModels;

public class ViewModelBase<T>: ObservableObject //INotifyPropertyChanged
{
    private  T _model;

    public ViewModelBase(T model)
    {
        _model = model;
    }


    public T Model
    {
        get => _model;
        set
        {
            if (value.Equals(_model)) return;
            _model = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

   protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}