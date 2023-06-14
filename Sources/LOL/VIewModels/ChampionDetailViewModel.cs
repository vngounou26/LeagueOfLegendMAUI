using CommunityToolkit.Mvvm.Input;

using LOL.Pages;

using Microsoft.Maui.Controls;

using MVVM_Toolkit.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL.VIewModels
{
    public partial class ChampionDetailViewModel
    {
        
        public ChampionDetailViewModel(ChampionMgrVm championMgr, ChampionVM championVm)
        {
            ChampionVm = championVm;
            ChampionMgrVm = championMgr;
        }
        public ChampionVM ChampionVm { get; }
        private ChampionMgrVm ChampionMgrVm { get; }



        [RelayCommand]
        private async void EditChampion()
        {
            await Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm, new EditableChampionVM( ChampionVm), ChampionVm)));
        }

        [RelayCommand]
        private void Back()
        {
            Shell.Current.Navigation.PopAsync();
        }

    }
}
