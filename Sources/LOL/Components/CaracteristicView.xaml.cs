using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOL.Components;

public partial class CaracteristicView : ContentView
{
    public CaracteristicView()
    {
        InitializeComponent();
    }

    public StackOrientation StackOrientation
    {
        get => (StackOrientation)GetValue(StackOrientationProperty);
        set => SetValue(StackOrientationProperty, value);
    }

    public LayoutOptions KeyHorizontalAlignment
    {
        get => (LayoutOptions)GetValue(KeyHorizontalAlignmentProperty);
        set => SetValue(KeyHorizontalAlignmentProperty, value);
    }

    

    public LayoutOptions ValueHorizontalAlignment
    {
        get => (LayoutOptions)GetValue(ValueHorizontalAlignmentProperty);
        set => SetValue(ValueHorizontalAlignmentProperty, value);
    }

    BindableProperty StackOrientationProperty = BindableProperty.Create(
            nameof(StackOrientation),
                typeof(StackOrientation), 
                    typeof(CaracteristicView)
    );

    BindableProperty KeyHorizontalAlignmentProperty = BindableProperty.Create(
               nameof(KeyHorizontalAlignment),
                      typeof(LayoutOptions), 
                             typeof(CaracteristicView)
           );

    BindableProperty ValueHorizontalAlignmentProperty = BindableProperty.Create(
                      nameof(ValueHorizontalAlignment),
                                           typeof(LayoutOptions), 
                                                                       typeof(CaracteristicView)
                  );


}