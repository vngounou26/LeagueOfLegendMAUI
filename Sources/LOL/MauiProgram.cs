using CommunityToolkit.Maui;

using LOL.Components;
using LOL.Pages;
using LOL.VIewModels;
using Microsoft.Extensions.Logging;
using Model;
using MVVM_Toolkit.ViewModels;
using StubLib;

namespace LOL
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
               builder .Services.AddSingleton<IDataManager,StubData>()
                .AddSingleton<ChampionMgrVm>();
               builder.Services.AddTransient<ChampionsView>().AddTransient<ChampionMgrVm>();
               builder.Services.AddTransient<ChampionsViewModel>();
               builder.Services.AddTransient<EditChampionView>().AddTransient<EditionViewModel>();
               builder.Services.AddTransient<TabBarView>().AddTransient<TabBarViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}