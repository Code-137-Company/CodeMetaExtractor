using MediaInfo;
using TagLib;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class AudioExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            data.Add(string.Empty, string.Empty);

            var file = TagLib.File.Create(path);

            var fileType = file.GetType();
            var fileProperties = fileType.GetProperties();

            foreach (var property in fileProperties)
            {
                var value = property.GetValue(file) ?? string.Empty;
                var added = data.TryAdd(property.Name, value.ToString());

                if (!added)
                    data.Add($"{property.Name}-{RandomNumber()}", value.ToString());
            }

            using (var mediaInfo = new MediaInfo.MediaInfo())
            {
                mediaInfo.Open(path);

                data.Add("Formato", mediaInfo.Get(StreamKind.General, 0, "Format"));
                data.Add("Duração", mediaInfo.Get(StreamKind.General, 0, "Duration") + " ms");
                data.Add("Tamanho do arquivo", mediaInfo.Get(StreamKind.General, 0, "FileSize") + " bytes");
                data.Add("Codec", mediaInfo.Get(StreamKind.Audio, 0, "Codec"));
                data.Add("Taxa de bits", mediaInfo.Get(StreamKind.Audio, 0, "BitRate") + " bps");
                data.Add("Canais", mediaInfo.Get(StreamKind.Audio, 0, "Channel(s)"));
                data.Add("Frequência", mediaInfo.Get(StreamKind.Audio, 0, "SamplingRate") + " Hz");
            }

            return data;
        }
    }
}
