namespace CodeMetaExtractor.Domain.Models
{
    public class MetadataModel
    {
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public IDictionary<string, string> Data { get; set; }

        public MetadataModel()
        {
            Data = new Dictionary<string, string>();
        }
    }
}
