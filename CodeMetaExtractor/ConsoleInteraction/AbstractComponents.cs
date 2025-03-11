using Spectre.Console;

namespace CodeMetaExtractor.ConsoleInteraction
{
    public abstract class AbstractComponents
    {
        protected void TitlePrompt(string title)
        {
            AnsiConsole.Write(
                new FigletText(title)
                    .Justify(Justify.Center)
                    .Color(Color.Red));

            AnsiConsole.WriteLine();
        }
        
        protected string TextPrompt(string text)
        {
            var result = AnsiConsole.Prompt(
                new TextPrompt<string>($"[teal]{text}[/] [white]>[/] "));

            AnsiConsole.WriteLine();

            return result;
        }
        
        protected void LabelErrorPrompt(string text)
        {
            AnsiConsole.Markup($"[red]{text}[/]");

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
        
        protected string SelectPrompt(string title, params string[] choices)
        {
            var result = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[red3]{title}[/]")
                    .AddChoices(choices));

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

            return result;
        }
    }
}
