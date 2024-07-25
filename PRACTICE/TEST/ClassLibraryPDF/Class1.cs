using System.Drawing;
using SautinSoft;

namespace ClassLibraryPDF
{
    public class Class1
    {
        
        public void inicializar()
        {
            PdfFocus pdf = new PdfFocus();
        
            pdf.OpenPdf(@"D:\Progarmacion\C-\PRACTICE\TEST\ConsoleAppPDF\ConsoleAppPDF\pdf\Beginning gRPC with ASP.NET Core 6.pdf");

            if (pdf.PageCount > 0)
            {
                pdf.ImageOptions.Dpi = 300;
                var res = pdf.ToImage(@"C:\Users\Curtis\Desktop\Nueva carpeta\img.tiff", 1);
       
            }
        }

        }
}
