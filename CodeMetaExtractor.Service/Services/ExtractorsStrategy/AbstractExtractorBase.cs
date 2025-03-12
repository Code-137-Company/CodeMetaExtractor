using MathNet.Numerics.Random;
using System.IO;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy
{
    public abstract class AbstractExtractorBase
    {
        protected long RandomNumber()
        {
            Random rand = new Random();
            return rand.NextInt64(10000, 99999);
        }

        protected Dictionary<string, string> GetDefaultInfos(string path)
        {
            var data = new Dictionary<string, string>();

            var fileInfo = new FileInfo(path);

            var fileType = fileInfo.GetType();
            var fileProperties = fileType.GetProperties();

            foreach (var property in fileProperties)
            {
                var value = property.GetValue(fileInfo) ?? string.Empty;
                var added = data.TryAdd(property.Name, value.ToString());

                if (!added)
                    data.Add($"{property.Name}-{RandomNumber()}", value.ToString());
            }

            return data;
        }
    }
}
