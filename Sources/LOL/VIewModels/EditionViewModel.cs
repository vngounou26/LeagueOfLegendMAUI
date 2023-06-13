using Microsoft.Maui.Controls;

using Model;
using MVVM_Toolkit.ViewModels;

using System;
using static System.String;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LOL.VIewModels;

public class EditionViewModel:INotifyPropertyChanged
{
    public EditableChampionVM EditableChampionVm { get; }
    private ChampionVM _championVM { get; }
    public ChampionMgrVm ChampionMgrVm { get; }

    public EditionViewModel(ChampionMgrVm championMgr, EditableChampionVM editableChampionVm,ChampionVM championVM)
    {
        EditableChampionVm = editableChampionVm;
        ChampionMgrVm = championMgr;
        _championVM= championVM;
        Classes = Enum.GetValues<ChampionClass>().Where(c => c != ChampionClass.Unknown).ToArray();
        PickImageCommand = new Command(async () => await PickImage());
        PickIconCommand = new Command(async () => await PickIcon());
        SaveCommand = new Command(async () => await SaveChampion());
        CancelCommand = new Command(async () => await Cancel());
        IncrementCommand = new Command(Increment);
        IsNew = editableChampionVm.IsNew;
        Title = IsNew ? "New Champion" : "Edit Champion";
        ButtonTitle = IsNew ? "Create" : "Update";
        _key =IsNew ? Empty : EditableChampionVm.Characteristics.First().Key;
        _value =IsNew?0 : EditableChampionVm.Characteristics.First().Value;

        PropertyChanged += EditionViewModel_PropertyChanged;
    }

    private void EditionViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Value) && SelectedCharacteristic.Key==Key)
        {
            EditableChampionVm.UpdateCharacteristic(KeyValuePair.Create(Key, Value));
        }
    }

    private string _title=Empty;
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
    
    private string _buttonTitle=Empty;
    public string ButtonTitle
    {
        get => _buttonTitle;
        set
        {
            if (_buttonTitle == value) return;
            _buttonTitle = value;
            OnPropertyChanged();
        }
    }

    

    public KeyValuePair<string, int> SelectedCharacteristic
    {
        get=>KeyValuePair.Create(Key,Value);
        set
        {
            if (SelectedCharacteristic.Equals(value)) return;
            Key = value.Key;
            Value = value.Value;
            SelectedCharacteristic = value;
            OnPropertyChanged();
        }
    }



    private int _value;
    public int Value
    {
        get => _value;

        set
        {
            if (SelectedCharacteristic.Value == value) return;
            
            _value = value;
            SelectedCharacteristic = new KeyValuePair<string, int>(SelectedCharacteristic.Key, value);
            
            OnPropertyChanged();
        }
    }

    private string _key;
    public string Key
    {
        get => _key;
        set
        {
            if (SelectedCharacteristic.Key == value) return;
            _key = value;
            OnPropertyChanged();
        }
    }

    private bool _isNew;
    public bool IsNew
    {
        get => _isNew;
        set
        {
            if (_isNew == value) return;
            _isNew = value;
            OnPropertyChanged();
        }
    }
    

    public IEnumerable<ChampionClass> Classes { get; }
    
    public Command PickImageCommand { get; }
    public Command PickIconCommand { get; }
    public Command SaveCommand { get; }
    public Command IncrementCommand { get; }
    public Command CancelCommand { get; }

    private async Task PickImage()
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Pick an image"
        });
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            EditableChampionVm.Image= Convert.ToBase64String(bytes);
        }
    }

    private async Task PickIcon()
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Pick an image"
        });
        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            EditableChampionVm.Icon = Convert.ToBase64String(bytes);
        }
    }

    private async Task SaveChampion()
    {
        
        var champ = ChampionMgrVm.SaveChampion(_championVM,EditableChampionVm);
        if (champ != null)
        {
            await Application.Current!.MainPage!.DisplayAlert("Success", "Champion Saved", "Ok");
            await Shell.Current.Navigation.PopAsync();
        }
        else
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", "Champion not saved", "Ok");
        }
    }

    private async Task Cancel()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    private void Increment()
    {
        Value++;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}