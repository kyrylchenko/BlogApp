using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace BlogApp.UI.Models
{
    class ArticleModel
    {
        public ArticleDTO Article { get; set; }
        public string PDFText { get; set; }
         Stream PDFStream { get; set; }
        public ArticleModel() { }
        private void ReadPartOfPDFFile(Stream stream)
        {
            int maxLength = 100;
            stream.Position = 0;
            PdfReader reader = new PdfReader(stream);
           
            PDFText = "";
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                if (PDFText.Length > maxLength)
                    break;
                PDFText += PdfTextExtractor.GetTextFromPage(reader, page);
            }
            if (PDFText.Length > maxLength + 1)
                PDFText = PDFText.Substring(0, maxLength - 1);
            PDFText += "....click for more information";
          
        }
        public ArticleModel(ArticleDTO article)
        {
            Article = article;
            try
            {
                PDFStream = new MemoryStream();
                AuthorizationDataManager.BlogService.DownloadFile(Article.FilePath).CopyTo(PDFStream);
                ReadPartOfPDFFile(PDFStream);
            }
            catch(Exception ex)
            {
                PDFText = "This aticle doesn't contain any text...click for see it";
            }
        }
    }
}
