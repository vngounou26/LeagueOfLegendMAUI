using Model;

using MVVM_Toolkit.Helpers;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.String;

namespace MVVM_Toolkit.ViewModels
{
    public class EditableChampionVM : ViewModelBase<ChampionVM>
    {
        public ChampionVM? EditableChampion { get; set; }
        
        //public event PropertyChangedEventHandler? PropertyChanged;
        public EditableChampionVM(ChampionVM? model) : base(model)
        {
            IsNew = model is null;
            EditableChampion = !IsNew ? model : null;
            _image = IsNew ? Empty : EditableChampion!.Model.Image.Base64;
            _icon = IsNew ? Empty : EditableChampion!.Model.Icon;
            _name = IsNew ? Empty : EditableChampion!.Model.Name;
            _bio = IsNew ? Empty : EditableChampion!.Model.Bio;
            _class = IsNew ? ChampionClass.Unknown : EditableChampion!.Class;

            _characteristics = IsNew ? new(): new(EditableChampion!.Model.Characteristics);
            Skills= new ReadOnlyObservableCollection<SkillVm>(_skills);
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(_characteristics);


        }

        public bool IsNew { get; private set; }

        private string _name ;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private ChampionClass _class;
        public ChampionClass Class
        {
            get =>  _class;
            
            set=> SetProperty(ref _class, value);
        }

        private string _bio;
        public string Bio
        {
            get => _bio;
            set=> SetProperty(ref _bio, value);
        }

        private string _icon ;
        public string Icon
        {
            get => _icon;
            set=> SetProperty(ref _icon, value);
        }

        private string _image;
        public string Image
        {
            get =>_image ;
            set=> SetProperty(ref _image, value);
        }

        public void AddCharacteristic(KeyValuePair<string, int> someCharacteristic)
        {
            if (someCharacteristic.Key == null) return;
            if (!IsNew)
            {
                if (Characteristics.Contains(someCharacteristic)) return;
                EditableChampion!.Model.AddCharacteristics(new Tuple<string, int>(someCharacteristic.Key, someCharacteristic.Value));
                OnPropertyChanged(nameof(Characteristics));
            }
            EditableChampion!.Model.AddCharacteristics(new Tuple<string, int>(someCharacteristic.Key, someCharacteristic.Value));
            OnPropertyChanged(nameof(Characteristics));
        }

        public void UpdateCharacteristic(KeyValuePair<string, int> someCharacteristic)
        {
            if (someCharacteristic.Key == null) return;
            if (!IsNew)
            {
                var oldCharacteristic = Characteristics.FirstOrDefault(x => x.Key == someCharacteristic.Key);
                if (oldCharacteristic.Key == null) return;
                _characteristics.Remove(oldCharacteristic);
                _characteristics.Add(someCharacteristic);
            }
        }


        private ObservableCollection<KeyValuePair<String, int>> _characteristics;
        public ReadOnlyObservableCollection<KeyValuePair<String, int>> Characteristics
        {
            get; 
        }

        //private void OnPropertyChanged([CallerMemberName] string propertyName = "") 
        //    =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ObservableCollection<SkillVm> _skills
        {
            get => IsNew ? new(): EditableChampion!.Skills;
            set => _skills = value;
        }
        public ReadOnlyObservableCollection<SkillVm> Skills
        {
            get; private set;
        }

        public void SaveChampion()
        {
            if (!IsNew)
            {
                
                EditableChampion!.Class= Class;
                EditableChampion.Icon= Icon;
                EditableChampion.Image= Image;
                EditableChampion.Bio= Bio;
                foreach (var skill in Skills)
                {
                    EditableChampion.Model.AddSkill(skill.Model);
                }
                //foreach (var characteristic in Characteristics)
                //{
                //    var (key, value) = characteristic;
                //    EditableChampion.Model.AddCharacteristics(new Tuple<string, int>(key, value));
                //}
                EditableChampion.Characteristics = _characteristics;
            }
            else
            {
                EditableChampion = new ChampionVM(new Champion(Name, Class, Icon, Image, Bio));
                foreach (var skill in Skills)
                {
                    EditableChampion.Model.AddSkill(skill.Model);
                }
                foreach (var characteristic in Characteristics)
                {
                    var (key, value) = characteristic;
                    EditableChampion.Model.AddCharacteristics(new Tuple<string, int>(key, value));
                }

            }
        }
    }
}
