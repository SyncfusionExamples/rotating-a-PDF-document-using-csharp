using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

//Created the PDF document.
PdfDocument document = new PdfDocument();
//Add a new page
PdfPage page = document.Pages.Add();

FileStream fileStream = new FileStream("../../../Data/input.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//Load a bitmap
PdfBitmap image = new PdfBitmap(fileStream);
//save the current graphics state
PdfGraphicsState state = page.Graphics.Save();
//Rotate the coordinate system
page.Graphics.RotateTransform(40);
//Draw image
image.Draw(page, 280, 20);
//Restore the graphics state
page.Graphics.Restore(state);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    document.Save(outputFileStream);
}
//Close the document.
document.Close(true);