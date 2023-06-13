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
    public class ChampionDetailViewModel
    {
        
        public ChampionDetailViewModel(ChampionMgrVm championMgr, ChampionVM championVm)
        {
            ChampionVm = championVm;
            ChampionMgrVm = championMgr;
            EditChampionCommand = new Command(EditChampion);
            BackCommand = new Command(Back);
        }
        public ChampionVM ChampionVm { get; }
        private ChampionMgrVm ChampionMgrVm { get; }


        public Command EditChampionCommand { get; }
        public Command BackCommand { get; }


        private async void EditChampion()
        {
            await Shell.Current.Navigation.PushAsync(new EditChampionView(new EditionViewModel(ChampionMgrVm, new EditableChampionVM( ChampionVm), ChampionVm)));
        }

        private void Back()
        {
            Shell.Current.Navigation.PopAsync();
        }

    }
}
