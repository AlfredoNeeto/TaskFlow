using CommunityToolkit.Maui;
using DotNet.Meteor.HotReload.Plugin;
using Microsoft.Extensions.Logging;
using TaskFlow.Views;

namespace TaskFlow;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		DependencyInjectionConfig.RegisterDependencies(builder.Services);
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
#if DEBUG
			.EnableHotReload()
#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
				fonts.AddFont("Poppins-ExtraBold.ttf", "PoppinsExtraBold");
				fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");
				fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");

				//Icones
				fonts.AddFont("MaterialIconsRound-Regular.otf", "GoogleIcons");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
