using CodeMetaExtractor.Domain.Models;
using CodeMetaExtractor.Service.Services.ExtractorsStrategy;

namespace CodeMetaExtractor.Service.Services.ExtractMetadataService
{
    public interface IExtractMetadata
    {
        MetadataModel Extract(string path, IExtractorsBase extractor);
    }
}
