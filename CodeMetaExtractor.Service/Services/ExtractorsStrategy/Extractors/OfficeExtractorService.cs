
using NPOI.OpenXml4Net.OPC;
using NPOI.XSSF.UserModel;

namespace CodeMetaExtractor.Service.Services.ExtractorsStrategy.Extractors
{
    public class OfficeExtractorService : AbstractExtractorBase, IExtractorsBase
    {
        public IDictionary<string, string> Extract(string path)
        {
            var data = new Dictionary<string, string>();

            data = GetDefaultInfos(path);

            data.Add(string.Empty, string.Empty);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var pkg = OPCPackage.Open(fs);
                var workbook = new XSSFWorkbook(pkg);

                var props = workbook.GetProperties();

                data.Add("Author", props.CoreProperties.Creator);
                data.Add("Title", props.CoreProperties.Title);
                data.Add("Subject", props.CoreProperties.Subject);
                data.Add("Created", props.CoreProperties.Created.ToString());
                data.Add("Modified", props.CoreProperties.Modified.ToString());
                data.Add("LastPrinted", props.CoreProperties.LastPrinted.ToString());
                data.Add("LastModifiedByUser", props.CoreProperties.LastModifiedByUser);
                data.Add("Category", props.CoreProperties.Category);
                data.Add("ContentStatus", props.CoreProperties.ContentStatus);
                data.Add("ContentType", props.CoreProperties.ContentType);
                data.Add("Description", props.CoreProperties.Description);
                data.Add("Identifier", props.CoreProperties.Identifier);
                data.Add("Keywords", props.CoreProperties.Keywords);
                data.Add("Revision", props.CoreProperties.Revision);

                data.Add("AppVersion", props.ExtendedProperties.AppVersion);
                data.Add("Application", props.ExtendedProperties.Application);
                data.Add("Characters", props.ExtendedProperties.Characters.ToString());
                data.Add("CharactersWithSpaces", props.ExtendedProperties.CharactersWithSpaces.ToString());
                data.Add("Company", props.ExtendedProperties.Company);
                data.Add("HiddenSlides", props.ExtendedProperties.HiddenSlides.ToString());
                data.Add("HyperlinkBase", props.ExtendedProperties.HyperlinkBase);
                data.Add("Lines", props.ExtendedProperties.Lines.ToString());
                data.Add("MMClips", props.ExtendedProperties.MMClips.ToString());
                data.Add("Manager", props.ExtendedProperties.Manager);
                data.Add("Notes", props.ExtendedProperties.Notes.ToString());
                data.Add("Pages", props.ExtendedProperties.Pages.ToString());
                data.Add("Paragraphs", props.ExtendedProperties.Paragraphs.ToString());
                data.Add("PresentationFormat", props.ExtendedProperties.PresentationFormat);
                data.Add("Slides", props.ExtendedProperties.Slides.ToString());
                data.Add("Template", props.ExtendedProperties.Template);
                data.Add("TotalTime", props.ExtendedProperties.TotalTime.ToString());
                data.Add("Words", props.ExtendedProperties.Words.ToString());
            }

            return data;
        }
    }
}
