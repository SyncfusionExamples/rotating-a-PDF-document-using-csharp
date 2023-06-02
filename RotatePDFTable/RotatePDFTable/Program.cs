using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf;
using System.Data;
using Syncfusion.Drawing;


//Create a new PDF document. 
PdfDocument document = new PdfDocument();
//Add a page. 
PdfPage page = document.Pages.Add();
//Create a PdfGrid. 
PdfGrid pdfGrid = new PdfGrid();
//Add a handler to rotate the table. 
pdfGrid.BeginPageLayout += PdfGrid_BeginPageLayout;

//Create a DataTable. 
DataTable dataTable = new DataTable();
//Add columns to the DataTable. 
dataTable.Columns.Add("ID", typeof(int));
dataTable.Columns.Add("Name", typeof(string));
dataTable.Columns.Add("Type", typeof(string));
dataTable.Columns.Add("Date", typeof(DateTime));

//Add rows to the DataTable. 
for (int i = 0; i < 10; i++)
{
    dataTable.Rows.Add(57, "AAA", "ABC", DateTime.Now);
    dataTable.Rows.Add(130, "BBB", "BCD", DateTime.Now);
    dataTable.Rows.Add(92, "CCC", "CDE", DateTime.Now);
}
//Assign data source. 
pdfGrid.DataSource = dataTable;
//Set a repeat header for the table.  
pdfGrid.RepeatHeader = true;
//Draw a grid to the page of a PDF document. 
pdfGrid.Draw(page, new RectangleF(100, 20, 0, page.GetClientSize().Width));

//Create the filestream to save the PDF document.  
FileStream fileStream = new FileStream("Output.pdf", FileMode.CreateNew, FileAccess.ReadWrite);
document.Save(fileStream);
//Close the document. 
document.Close(true);

void PdfGrid_BeginPageLayout(object sender, Syncfusion.Pdf.Graphics.BeginPageLayoutEventArgs e)
{
    PdfPage page = e.Page;
    PdfGraphics graphics = e.Page.Graphics;
    //Translate the coordinate system to the required position. 
    graphics.TranslateTransform(page.GetClientSize().Width, 0);
    //Rotate the coordinate system. 
    graphics.RotateTransform(90);
}