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
        set=> SetProperty(Model.Description, value, Model, (model, val) => model.Description = val);
    }
    
    public SkillType Type
    {
        get => Model.Type;
    }
    
}