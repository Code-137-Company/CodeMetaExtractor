using Spectre.Console;

namespace CodeMetaExtractor.ConsoleInteraction.Menus
{
    public class ExtractMenu : AbstractComponents
    {
        public void ExtractorStruct(string path)
        {
            AnsiConsole.Clear();

            var fileName = Path.GetFileName(path).Split('.').First();
            var fileExtension = Path.GetExtension(path);

            var infos = new Table();

            infos.AddColumn("Type");
            infos.AddColumn("Value");

            infos.AddRow("[teal]File Extension[/]", $"[cyan3]{fileExtension}[/]");
            infos.AddRow("[teal]File Name[/]", $"[cyan3]{fileName}[/]");
            infos.AddRow("[teal]Full Path[/]", $"[cyan3]{path}[/]");

            infos.Expand = true;

            AnsiConsole.Write(infos);

            AnsiConsole.WriteLine();

            var result = SelectPrompt("Select Option", new string[]
            {
                "[teal]Show Metadata[/]",
                "[teal]Extract Metadata[/]",
                "[yellow2]Done[/]"
            });
        }
    }
}
