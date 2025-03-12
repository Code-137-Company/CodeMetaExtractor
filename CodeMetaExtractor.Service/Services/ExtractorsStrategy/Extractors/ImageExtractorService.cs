using MetadataExtractor;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class ImageExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            data.Add(string.Empty, string.Empty);

            var directories = ImageMetadataReader.ReadMetadata(path);

            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {
                    var added = data.TryAdd(tag.Name, tag.Description);

                    if (!added)
                        data.Add($"{tag.Name}-{RandomNumber()}", tag.Description);
                }
            }

            return data;
        }
    }
}
