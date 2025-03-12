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
        private readonly ShowMetadataMenu _showMetadataMenu;

        public ConsoleMenus(SelectFileMenu selectFileMenu, ExtractMenu extractMenu, ShowMetadataMenu showMetadataMenu)
        {
            _selectFileMenu = selectFileMenu;
            _extractMenu = extractMenu;
            _showMetadataMenu = showMetadataMenu;
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
                    
                    case PageEnum.ShowMetadata:
                        ShowMetadataPage(path);
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
            var option = _extractMenu.ExtractorStruct(path);

            switch (option)
            {
                case ExtractMenuOptionEnum.ShowMetadata:
                    Page = PageEnum.ShowMetadata;
                    break;
                
                case ExtractMenuOptionEnum.ExtractMetadata:
                    break;
                
                default:
                case ExtractMenuOptionEnum.Done:
                    Page = PageEnum.FilePath;
                    break;
            }
        }

        private void ShowMetadataPage(string path)
        {
            _showMetadataMenu.ShowMetadata(path);

            Page = PageEnum.Extractor;
        }
    }
}
