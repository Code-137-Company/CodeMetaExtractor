using CodeMetaExtractor.Service.Services.ExtractMetadataService;
using CodeMetaExtractor.Service.Services.ExtractorsStrategy;
using CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors;
using Spectre.Console;

namespace CodeMetaExtractor.ConsoleInteraction.Menus
{
    public class ShowMetadataMenu : AbstractComponents
    {
        private readonly IExtractMetadata _extractMetadata;

        public ShowMetadataMenu(IExtractMetadata extractMetadata)
        {
            _extractMetadata = extractMetadata;
        }

        public void ShowMetadata(string path)
        {
            var imageExtractor = new HashSet<string> { ".jpg", ".jpeg", ".png", ".gif" };
            var audioExtractor = new HashSet<string> { ".mp3", ".flac", ".wav" };
            var pdfExtractor = new HashSet<string> { ".pdf" };
            var videoExtractor = new HashSet<string> { ".mp4", ".mkv", ".avi" };
            var officeExtractor = new HashSet<string> { ".doc", ".docx", ".xls", ".xlsx" };
            var textExtractor = new HashSet<string> { ".txt" };

            IExtractorsBase extractor = Path.GetExtension(path) switch
            {
                var ext when imageExtractor.Contains(ext) => new ImageExtractorService(),
                var ext when audioExtractor.Contains(ext) => new AudioExtractorService(),
                var ext when pdfExtractor.Contains(ext) => new PdfExtractorService(),
                var ext when videoExtractor.Contains(ext) => new VideoExtractorService(),
                var ext when officeExtractor.Contains(ext) => new OfficeExtractorService(),
                var ext when textExtractor.Contains(ext) => new GenericExtractorService(),
                _ => new GenericExtractorService(),
            };

            var metadata = _extractMetadata.Extract(path, extractor);

            AnsiConsole.Clear();

            var table = new Table();
            table.Expand = true;

            table.AddColumn("Name");
            table.AddColumn("Data");

            table.AddRow($"[teal]Full Path[/]", $"[cyan3]{metadata.FullPath}[/]");
            table.AddRow($"[teal]File Name[/]", $"[cyan3]{metadata.FileName}[/]");
            table.AddRow($"[teal]Extension[/]", $"[cyan3]{metadata.Extension}[/]");
            table.AddRow($"[teal]File Size (bytes)[/]", $"[cyan3]{metadata.Size}[/]");
            table.AddRow($"[teal]Creation Time[/]", $"[cyan3]{metadata.CreationTime}[/]");
            table.AddRow($"[teal]Last Write Time[/]", $"[cyan3]{metadata.LastWriteTime}[/]");

            table.AddRow(string.Empty, string.Empty);

            foreach (var data in metadata.Data)
            {
                table.AddRow($"[cornflowerblue]{data.Key}[/]", $"[darkcyan]{data.Value}[/]");
            }

            AnsiConsole.Write(table);

            SelectPrompt(string.Empty, new string[]
            {
                "[yellow2]Done[/]"
            });
        }
    }
}
