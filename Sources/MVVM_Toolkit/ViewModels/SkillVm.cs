using Model;

namespace MVVM_Toolkit.ViewModels;

public class SkillVm:ViewModelBase<Skill>
{
    public SkillVm(Skill model) : base(model)
    {
    }
    
    public string Name
    {
        get => Model.Name;
    }
    
    public string Description
    {
        get => Model.Description;
        set
        {
            if (Model.Description == value) return;
            Model.Description = value;
            OnPropertyChanged();
        }
    }
    
    public SkillType Type
    {
        get => Model.Type;
    }
    
}