using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace rectangle
{
    public class CreatePdf
    {
        public static string MainStamping(string fileFullPath, List<string> imagePath, string mediaField)
        {
            FileStream pdfOutputFile = new FileStream(fileFullPath, FileMode.Create);
            PdfConcatenate pdfConcatenate = new PdfConcatenate(pdfOutputFile);

            PdfReader result = null;

            for (int i = 0; i < imagePath.Count; i++)
            {
                result = CreatePDFDocument1(imagePath[i], mediaField);
                pdfConcatenate.AddPages(result);
            }

            pdfConcatenate.Close();
            return fileFullPath;
        }

        public static PdfReader CreatePDFDocument1(string imagePath, string mediaField)
        {
            PdfReader pdfReader = null;
            
            iTextSharp.text.Image instanceImg = iTextSharp.text.Image.GetInstance(imagePath);

            if ((instanceImg.ScaledHeight >= instanceImg.ScaledWidth) || (instanceImg.ScaledWidth <= 714))
            {
                pdfReader = new PdfReader(imagePath);
            }
            else
            {
                pdfReader = new PdfReader(imagePath);
            }

            MemoryStream memoryStream = new MemoryStream();
            PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);

            AcroFields testForm = pdfStamper.AcroFields;
            testForm.SetField("MediaField", mediaField);

            PdfContentByte overContent = pdfStamper.GetOverContent(1);
            IList<AcroFields.FieldPosition> fieldPositions = testForm.GetFieldPositions("ImageField");

            if (fieldPositions == null || fieldPositions.Count <= 0) throw new ApplicationException("Error locating field");
            AcroFields.FieldPosition fieldPosition = fieldPositions[0];
            iTextSharp.text.Rectangle imageRect = new Rectangle(fieldPosition.position.Top, fieldPosition.position.Left, fieldPosition.position.Bottom, fieldPosition.position.Right);

            instanceImg.ScaleToFit(imageRect.Height, -1 * imageRect.Width);
            instanceImg.SetAbsolutePosition(fieldPosition.position.Left, (fieldPosition.position.Top - (instanceImg.ScaledHeight)));

            overContent.AddImage(instanceImg);
            pdfStamper.FormFlattening = true;
            pdfStamper.Close();

            PdfReader resultReader = new PdfReader(memoryStream.ToArray());
            pdfReader.Close();

            return resultReader;
        }
    }
}
