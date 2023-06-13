using System.Diagnostics;
using LOL.Pages;
using Model;

using MVVM_Toolkit.ViewModels;

namespace LOL.VIewModels;

public class ChampionsViewModel
{
    public ChampionsViewModel(ChampionMgrVm mgrVm)
    {
        DisplayDetailCommand = new Command(DisplayDetail);
        NextPageCommand = new Command(NextPage);
        PreviousPageCommand = new Command(PreviousPage,CanExecutePrevious);
        EditChampionCommand = new Command<ChampionVM?>(EditChampion);
        NewChampionCommand = new Command(NewChampion);
        ChampionMgrVm = mgrVm;
    }
    
    public ChampionMgrVm ChampionMgrVm { get; }
    public ChampionVM SelectedChampion { get; set; }
    
    public Command DisplayDetailCommand{ get; }
    public Command NextPageCommand { get; }
    public Command PreviousPageCommand { get; }
    public Command EditChampionCommand { get; }
    public Command NewChampionCommand { get; }
    

    private void EditChampion(ChampionVM? championVM=null)
    {
        if (championVM == null)
        {
            Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm, new EditableChampionVM(SelectedChampion), SelectedChampion)));
        }
        else
        {
            Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm, new EditableChampionVM(championVM), championVM)));
        }
    }

    private void NewChampion()
    {
        Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm,new EditableChampionVM(null),null)));
    }

    private async void DisplayDetail()
    {
        await Shell.Current.Navigation.PushAsync(new ChampionDetailView(new ChampionDetailViewModel(ChampionMgrVm, SelectedChampion)));
    }

    private void NextPage()
    {
        ChampionMgrVm.Page++;
        RefreshCanExecute();
    }

    private void PreviousPage()
    {
        ChampionMgrVm.Page--;
        RefreshCanExecute();

    }

    private bool CanExecutePrevious()
    {
        return ChampionMgrVm.Page > 1;
    }

    void RefreshCanExecute()
    {
        PreviousPageCommand.ChangeCanExecute();
    }

    


}