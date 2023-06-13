using System.Collections.ObjectModel;
using Model;
using CommunityToolkit.Mvvm;


using MVVM_Toolkit.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM_Toolkit.ViewModels;

public class ChampionVM :  ViewModelBase<Champion>
{
    public ChampionVM(Champion model) : base(model)
    {
    }

    public ChampionClass Class
    {
        get => Model.Class;
        set=> SetProperty(Model.Class, value, Model, (model, val) => model.Class = val);
    }

    public string Name
    {
        get => Model.Name;
    }


    public string Bio
    {
        get => Model.Bio;
        set=> SetProperty(Model.Bio, value, Model, (model, val) => model.Bio = val);
    }

    public string Icon
    {
        get => Model.Icon;
        set=> SetProperty(Model.Icon, value, Model, (model, val) => model.Icon = val);
    }

    public void AddCharacteristic(Tuple<string,int> someCharacteristic)
    {
        if (someCharacteristic == null) return;
        if (Model.Characteristics.ContainsKey(someCharacteristic.Item1)) return;
        Model.AddCharacteristics(someCharacteristic);
        OnPropertyChanged(nameof(Characteristics));
    }
    
    public ObservableCollection<KeyValuePair<String,int>> Characteristics
    {
        get=> new(Model.Characteristics);
        set
        {
            foreach (var characteristic in value)
            {
                Model.AddCharacteristics(Tuple.Create(characteristic.Key, characteristic.Value));
            }
            OnPropertyChanged();
        }
    }
    public string Image
    {
        get => Model.Image.Base64;
        set=> SetProperty(Model.Image.Base64, value, Model, (model, val) => model.Image.Base64 = val);
    }

    
    
    public ObservableCollection<SkillVm> Skills
    {
        get
        {
            var skills = new ObservableCollection<SkillVm>();
            foreach (var skill in Model.Skills)
            {
                skills.Add(new SkillVm(skill));
            }
            return skills;
        }
    }

}
