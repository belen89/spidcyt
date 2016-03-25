using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.IO;
/// <summary>
/// Representa el encabezado de un PDF
/// </summary>
public class Header : PdfPageEventHelper
{
    /// <summary>
    /// Crea el encabezado de un documento. 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="document"></param>
    public override void OnEndPage(PdfWriter writer, Document document)
    {
        Rectangle pageSize = document.PageSize;
        //string html =  "<img alt=\"Logo iText\" src=\"http://www.frc.utn.edu.ar/Skins/plantillas/prensa/imagenes/logoFrcPpal.jpg\" height=\"40px\" width=\"450px\">";
        Uri uri = new Uri(System.Web.HttpContext.Current.Server.MapPath("~") +"/Images/membreteUTN.png");
        Image image = Image.GetInstance(uri);

        Paragraph header = new Paragraph();
        header.Alignment = Element.ALIGN_CENTER;
        PdfPTable headerTbl = new PdfPTable(1);
        headerTbl.TotalWidth = 580;
        headerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cell = new PdfPCell(header);
        cell.Border = 0;
        cell.Image = image;
        cell.PaddingLeft= 10;
        headerTbl.AddCell(cell);
        headerTbl.WriteSelectedRows(0, -1, pageSize.GetLeft(5), pageSize.GetTop(5), writer.DirectContent);

    }
}