using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOL.VIewModels;

namespace LOL.Pages;

public partial class EditChampionView : ContentPage
{
    public EditChampionView(EditionViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}