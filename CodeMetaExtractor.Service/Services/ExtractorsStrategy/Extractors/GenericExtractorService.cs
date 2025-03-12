namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class GenericExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            return data;
        }
    }
}
