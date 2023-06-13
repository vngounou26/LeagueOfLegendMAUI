using LOL.VIewModels;
using MVVM_Toolkit;
using MVVM_Toolkit.ViewModels;

namespace LOL.Pages;

public partial class ChampionsView : ContentPage
{
	public ChampionsViewModel ChampionViewModel { get; }
	public ChampionsView(ChampionsViewModel championsVm)
	{
		InitializeComponent();
		BindingContext = championsVm;
		//ChampionViewModel = new ChampionsViewModel();
	}

}