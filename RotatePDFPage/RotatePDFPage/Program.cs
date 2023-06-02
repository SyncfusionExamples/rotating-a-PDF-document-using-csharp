using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;

FileStream inputStream = new FileStream("../../../Data/Input.pdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//Load the existing PDF document.
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);
//Gets the page.
PdfPageBase loadedPage = loadedDocument.Pages[0] as PdfPageBase;

//Set the rotation for loaded page.
loadedPage.Rotation = PdfPageRotateAngle.RotateAngle90;

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);
