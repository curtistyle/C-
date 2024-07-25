using GemBox.Pdf;
using System.Drawing;
ComponentInfo.SetLicense("FREE-LIMITED-KEY");

using (var document = PdfDocument.Load("D:\\Progarmacion\\C-\\PRACTICE\\TEST\\PdfToImg\\bin\\Debug\\net8.0\\inp\\Input.pdf"))
{
	var imageOption = new ImageSaveOptions(ImageSaveFormat.Jpeg)
	{
		PageNumber = 1,
		Width = 100,
	};

	document.Save("img.jpeg", imageOption);
}