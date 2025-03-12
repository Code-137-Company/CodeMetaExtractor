using UglyToad.PdfPig;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class PdfExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            data.Add(string.Empty, string.Empty);

            using (var pdf = PdfDocument.Open(path))
            {
                data.Add("Author", pdf.Information.Author);
                data.Add("CreationDate", pdf.Information.CreationDate);
                data.Add("ModifiedDate", pdf.Information.ModifiedDate);
                data.Add("Creator", pdf.Information.Creator);
                data.Add("Producer", pdf.Information.Producer);
                data.Add("Keywords", pdf.Information.Keywords);
                data.Add("Subject", pdf.Information.Subject);
                data.Add("Title", pdf.Information.Title);
                data.Add("IsEncrypted", pdf.IsEncrypted.ToString());
                data.Add("NumberOfPages", pdf.NumberOfPages.ToString());
                data.Add("Version", pdf.Version.ToString());
            }

            return data;
        }
    }
}
