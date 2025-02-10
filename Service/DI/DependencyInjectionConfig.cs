using TaskFlow.Views;

namespace TaskFlow;

public class DependencyInjectionConfig
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<IDatabaseService, DatabaseService>();
        services.AddSingleton<TaskPage>();
		services.AddTransient<TaskViewModel>();
    }
}
