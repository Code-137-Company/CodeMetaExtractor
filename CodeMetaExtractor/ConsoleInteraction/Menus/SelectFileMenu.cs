using Spectre.Console;

namespace CodeMetaExtractor.ConsoleInteraction.Menus
{
    public class SelectFileMenu : AbstractComponents
    {
        public string Error { get; private set; }

        public SelectFileMenu()
        {
            Error = string.Empty;
        }

        public string GetFilePath(out bool error)
        {
            error = false;

            AnsiConsole.Clear();

            TitlePrompt("Meta Extractor");

            var extensions = new string[]
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".gif",
                ".mp3",
                ".flac",
                ".wav",
                ".pdf",
                ".mp4",
                ".mkv",
                ".avi",
            };

            AnsiConsole.Write(new Panel(new Columns(extensions.Select(x => $"[teal]{x}[/]")))
                .Header("[red3]Extensions[/]")
                .Expand());

            AnsiConsole.WriteLine();

            if (!string.IsNullOrEmpty(Error))
            {
                LabelErrorPrompt(Error);
            }

            var path = TextPrompt("Full File Path [green4](C:\\Example.txt)[/]");

            path = path.Replace("\"", "");

            if (!File.Exists(path))
            {
                Error = "File does not exist";
                error = true;
            }

            if (!extensions.Contains(Path.GetExtension(path)))
            {
                Error = "Extension not allowed";
                error = true;
            }

            if (error)
                return string.Empty;

            Error = string.Empty;

            return path;
        }
    }
}
