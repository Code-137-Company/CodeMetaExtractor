using CodeMetaExtractor.ConsoleInteraction;
using CodeMetaExtractor.ConsoleInteraction.Menus;
using CodeMetaExtractor.Service.Services.ExtractMetadataService;
using CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors;
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
        serviceCollection.AddSingleton<ShowMetadataMenu>();

        serviceCollection.AddSingleton<IExtractMetadata, ExtractMetadata>();

        serviceCollection.AddSingleton<ImageExtractorService>();
        serviceCollection.AddSingleton<AudioExtractorService>();
        serviceCollection.AddSingleton<PdfExtractorService>();
        serviceCollection.AddSingleton<VideoExtractorService>();
        serviceCollection.AddSingleton<OfficeExtractorService>();
        serviceCollection.AddSingleton<GenericExtractorService>();
    }
}
