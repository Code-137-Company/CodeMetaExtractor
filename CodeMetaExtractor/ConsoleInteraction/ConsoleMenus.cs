using CodeMetaExtractor.ConsoleInteraction.Menus;
using CodeMetaExtractor.Domain.Enums;

namespace CodeMetaExtractor.ConsoleInteraction
{
    public class ConsoleMenus : AbstractComponents
    {
        public bool Started { get; private set; }
        public PageEnum Page { get; private set; }

        private readonly SelectFileMenu _selectFileMenu;
        private readonly ExtractMenu _extractMenu;

        public ConsoleMenus(SelectFileMenu selectFileMenu, ExtractMenu extractMenu)
        {
            _selectFileMenu = selectFileMenu;
            _extractMenu = extractMenu;
        }

        public void Stop() => Started = false;

        public void Start()
        {
            Started = true;

            Page = PageEnum.FilePath;

            var path = string.Empty;

            while (Started)
            {
                switch (Page)
                {
                    default:
                    case PageEnum.FilePath:
                        path = FilePathPage();
                        break;
                    
                    case PageEnum.Extractor:
                        ExtractorPage(path);
                        break;
                }

                
            }
        }

        private string FilePathPage()
        {
            var path = _selectFileMenu.GetFilePath(out bool error);

            if (!error)
            {
                Page = PageEnum.Extractor;

                return path;
            }

            return string.Empty;
        }
        
        private void ExtractorPage(string path)
        {
            _extractMenu.ExtractorStruct(path);

        }
    }
}
