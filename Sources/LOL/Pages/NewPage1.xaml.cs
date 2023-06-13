using LOL.VIewModels;

namespace LOL.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1(ChampionsViewModel championsViewModel)
	{
		InitializeComponent();
		BindingContext = championsViewModel;
	}
}