using CodeMetaExtractor.Domain.Enums;
using CodeMetaExtractor.Domain.Models;
using Spectre.Console;

namespace CodeMetaExtractor.ConsoleInteraction.Menus
{
    public class ExtractMenu : AbstractComponents
    {
        public ExtractMenuOptionEnum ExtractorStruct(string path)
        {
            AnsiConsole.Clear();

            var fileName = Path.GetFileName(path).Split('.').First();
            var fileExtension = Path.GetExtension(path);
            long fileSize;

            using (var file = File.OpenRead(path))
                fileSize = file.Length;

            var infos = new Table();

            infos.AddColumn("Name");
            infos.AddColumn("Data");

            infos.AddRow("[teal]Full Path[/]", $"[cyan3]{path}[/]");
            infos.AddRow("[teal]File Name[/]", $"[cyan3]{fileName}[/]");
            infos.AddRow("[teal]Extension[/]", $"[cyan3]{fileExtension}[/]");
            infos.AddRow("[teal]File Size (bytes)[/]", $"[cyan3]{fileSize}[/]");

            infos.Expand = true;

            AnsiConsole.Write(infos);

            AnsiConsole.WriteLine();

            var result = SelectPrompt("Select Option", new string[]
            {
                "[teal]Show Metadata[/]",
                "[teal]Extract Metadata[/]",
                "[yellow2]Done[/]"
            });

            if (result.Contains("Show Metadata"))
                return ExtractMenuOptionEnum.ShowMetadata;
            else if (result.Contains("Extract Metadata"))
                return ExtractMenuOptionEnum.ExtractMetadata;
            else if (result.Contains("Done"))
                return ExtractMenuOptionEnum.Done;

            return ExtractMenuOptionEnum.None;
        }
    }
}
