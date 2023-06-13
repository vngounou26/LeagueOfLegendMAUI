using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LOL.VIewModels;

public class TabBarViewModel:INotifyPropertyChanged
{
    private bool _isVisible;
    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            if (_isVisible == value) return;
            _isVisible = value;
            OnPropertyChanged();
        }
    }
    
    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            if (_title == value) return;
            _title = value;
            OnPropertyChanged();
        }
    }
    
    private string _icon;
    public string Icon
    {
        get => _icon;
        set
        {
            if (_icon == value) return;
            _icon = value;
            OnPropertyChanged();
        }
    }
    
    private string _actionTitle;
    public string ActionTitle
    {
        get => _actionTitle;
        set
        {
            if (_actionTitle == value) return;
            _actionTitle = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
}