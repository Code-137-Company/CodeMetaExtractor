using CodeMetaExtractor.ConsoleInteraction;
using CodeMetaExtractor.ConsoleInteraction.Menus;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMetaExtractor;
public static class Program
{
    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.ConfigureServices();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider.GetRequiredService<ConsoleMenus>().Start();
    }

    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ConsoleMenus>();
        serviceCollection.AddSingleton<SelectFileMenu>();
        serviceCollection.AddSingleton<ExtractMenu>();
    }
}
