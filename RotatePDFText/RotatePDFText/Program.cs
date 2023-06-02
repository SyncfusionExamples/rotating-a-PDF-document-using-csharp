using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Create a new PDF document.
PdfDocument pdfDocument = new PdfDocument();
//Add a page to the PDF document.
PdfPage pdfPage = pdfDocument.Pages.Add();
//Create PDF graphics for the page.
PdfGraphics graphics = pdfPage.Graphics;

//Set the font.
PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
//Add watermark text.
PdfGraphicsState state = graphics.Save();
graphics.RotateTransform(-40);
graphics.DrawString("Rotating a text in PDF document", font, PdfPens.Red, PdfBrushes.Red, new PointF(-150,450));

//Save the document into stream.
using (MemoryStream stream = new MemoryStream())
{
    pdfDocument.Save(stream);
    System.IO.File.WriteAllBytes("Output.pdf", stream.ToArray());
}
//Close the document.
pdfDocument.Close(true);