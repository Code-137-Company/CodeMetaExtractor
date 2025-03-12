using MediaInfo;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class VideoExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            data.Add(string.Empty, string.Empty);

            using (var mediaInfo = new MediaInfo.MediaInfo())
            {
                mediaInfo.Open(path);

                data.Add("Formato", mediaInfo.Get(StreamKind.General, 0, "Format"));
                data.Add("Duração", mediaInfo.Get(StreamKind.General, 0, "Duration") + " ms");
                data.Add("Tamanho do arquivo", mediaInfo.Get(StreamKind.General, 0, "FileSize") + " bytes");
                data.Add("Bitrate", mediaInfo.Get(StreamKind.Video, 0, "BitRate"));
                data.Add("Resolução", mediaInfo.Get(StreamKind.Video, 0, "Width") + "x" + mediaInfo.Get(StreamKind.Video, 0, "Height"));
                data.Add("FPS", mediaInfo.Get(StreamKind.Video, 0, "FrameRate"));
                data.Add("Codec de áudio", mediaInfo.Get(StreamKind.Audio, 0, "Codec"));
                data.Add("Canais de áudio", mediaInfo.Get(StreamKind.Audio, 0, "Channel(s)"));
            }

            return data;
        }
    }
}
