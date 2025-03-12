using CodeMetaExtractor.Domain.Models;
using CodeMetaExtractor.Service.Services.ExtractorsStrategy;

namespace CodeMetaExtractor.Service.Services.ExtractMetadataService
{
    public class ExtractMetadata : IExtractMetadata
    {
        public MetadataModel Extract(string path, IExtractorsBase extractor)
        {
            var file = new FileInfo(path);

            try
            {
                var data = extractor.Extract(path);

                var metadata = new MetadataModel()
                {
                    FullPath = path,
                    FileName = file.Name,
                    Extension = file.Extension,
                    Size = file.Length,
                    CreationTime = file.CreationTime,
                    LastWriteTime = file.LastWriteTime,
                    Data = data
                };

                return metadata;
            }
            catch (Exception ex)
            {
                var data = new Dictionary<string, string>();

                data.Add("Error", "Unable to extract metadata from file");

                return new MetadataModel()
                {
                    FullPath = path,
                    FileName = file.Name,
                    Extension = file.Extension,
                    Size = file.Length,
                    CreationTime = file.CreationTime,
                    LastWriteTime = file.LastWriteTime,
                    Data = data
                };
            }
        }
    }
}
