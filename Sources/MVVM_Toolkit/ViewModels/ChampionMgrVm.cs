using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Model;

namespace MVVM_Toolkit.ViewModels;

public class ChampionMgrVm:ViewModelBase<IDataManager>
{
    public ChampionMgrVm(IDataManager model) : base(model)
    {
        Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
        LoadChampions(Page, PageSize).ConfigureAwait(false);
        PropertyChanged += ChampionMgrVm_PropertyChanged;
    }
    
    private int _page = 1;
    public int Page
    {
        get => _page;
        set=> SetProperty(ref _page, value);
    }
    
    private int _pageSize = 5;
    public int PageSize
    {
        get => _pageSize;
        set=> SetProperty(ref _pageSize, value);
    }
    
    

    public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
    private ObservableCollection<ChampionVM> _champions = new();

    private  async Task LoadChampions(int page, int pageSize = 5)
    {
        var champs = await Model.ChampionsMgr.GetItems(page-1, pageSize,nameof(Champion.Name));
        foreach (var champ in champs)
        {
            _champions.Add(new ChampionVM(champ));
        }
    }

    public async Task SaveChampion(ChampionVM? champion, EditableChampionVM championVm)
    {
        if (championVm == null) return;
        if (!championVm.IsNew)
        {
            if (champion == null) return;
            championVm.SaveChampion();
            await Model.ChampionsMgr.UpdateItem(champion.Model, championVm.EditableChampion.Model);
        }

        else
        {
            championVm.SaveChampion();
            await Model.ChampionsMgr.AddItem(championVm.EditableChampion.Model);
        }
    }

    private async void ChampionMgrVm_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Page))
        {
            _champions.Clear();
           await LoadChampions(Page, PageSize);
        }
    }
    
    public IEnumerable<ChampionClass> AllClasses => Enum.GetValues<ChampionClass>();
    
    private ChampionClass _selectedClass = ChampionClass.Unknown;
    public ChampionClass SelectedClass
    {
        get => _selectedClass;
        set=> SetProperty(ref _selectedClass, value);
    }
    
}