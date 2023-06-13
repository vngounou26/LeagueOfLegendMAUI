using LOL.VIewModels;

namespace LOL.Components;

public partial class TabBarView : ContentView
{
    

    BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(TabBarView)
    );

    BindableProperty ActionTitleProperty = BindableProperty.Create(
        nameof(ActionTitle),
        typeof(string),
        typeof(TabBarView)
    );

    BindableProperty IsNewVisibleProperty = BindableProperty.Create(
        nameof(IsNewVisible),
        typeof(bool),
        typeof(TabBarView)
    );


    public TabBarView()
    {
        InitializeComponent();
    }

    BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(string),
        typeof(TabBarView)
    );

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string ActionTitle
    {
        get => (string)GetValue(ActionTitleProperty);
        set => SetValue(ActionTitleProperty, value);
    }

    public bool IsNewVisible
    {
        get => (bool)GetValue(IsNewVisibleProperty);
        set => SetValue(IsNewVisibleProperty, value);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.Navigation.PopAsync();
    }
}