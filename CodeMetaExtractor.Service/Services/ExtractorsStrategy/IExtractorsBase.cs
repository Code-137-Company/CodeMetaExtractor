using CodeMetaExtractor.Domain.Models;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy
{
    public interface IExtractorsBase
    {
        IDictionary<string, string> Extract(string path);
    }
}
