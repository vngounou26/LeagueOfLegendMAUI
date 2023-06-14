using System.Diagnostics;

using CommunityToolkit.Mvvm.Input;

using LOL.Pages;
using Model;

using MVVM_Toolkit.ViewModels;

namespace LOL.VIewModels;

public partial class ChampionsViewModel
{
    public ChampionsViewModel(ChampionMgrVm mgrVm)
    {
        NextPageCommand = new Command(NextPage);
        PreviousPageCommand = new Command(PreviousPage, CanExecutePrevious);
        ChampionMgrVm = mgrVm;
    }
    
    public ChampionMgrVm ChampionMgrVm { get; }
    public ChampionVM SelectedChampion { get; set; }
    public Command NextPageCommand { get; }
    public Command PreviousPageCommand { get; }

    [RelayCommand]
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

    [RelayCommand]
    private void NewChampion()
    {
        Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm,new EditableChampionVM(null),null)));
    }

    [RelayCommand]
    private async void DisplayDetail()
    {
        await Shell.Current.Navigation.PushAsync(new ChampionDetailView(new ChampionDetailViewModel(ChampionMgrVm, SelectedChampion)));
    }

    //[RelayCommand]
    private void NextPage()
    {
        ChampionMgrVm.Page++;
        RefreshCanExecute();
    }

    //[RelayCommand(CanExecute =nameof(CanExecutePrevious))]
    private void PreviousPage()
    {
        ChampionMgrVm.Page--;
        RefreshCanExecute();

    }


    private bool CanExecutePrevious()
    {
        return ChampionMgrVm.Page > 1;
    }
    public void RefreshCanExecute()
    {
        PreviousPageCommand.ChangeCanExecute();
    }


}