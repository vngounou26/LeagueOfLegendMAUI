using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOL.VIewModels;

using MVVM_Toolkit.ViewModels;

namespace LOL.Pages;

public partial class ChampionDetailView : ContentPage
{
    public ChampionDetailView(ChampionDetailViewModel detailViewModel)
    {
        InitializeComponent();
        BindingContext = detailViewModel;
    }

}