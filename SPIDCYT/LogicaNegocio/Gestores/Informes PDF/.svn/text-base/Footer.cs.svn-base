using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.xml;
using System.IO;

/// <summary>
/// Pie de página de los archivos PDF
/// </summary>
public partial class Footer : PdfPageEventHelper
{
    /// <summary>
    /// Crea el pie de página para un documento a imprimir
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="doc"></param>
    public override void OnEndPage(PdfWriter writer, Document doc)
    {
        string textFooter = "Documento generado: " + DateTime.Now.ToShortDateString()+ " - Página: " + doc.PageNumber;
        Paragraph footer = new Paragraph(textFooter, FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.ITALIC));
        footer.Alignment = Element.ALIGN_RIGHT;
        PdfPTable footerTbl = new PdfPTable(1);
        footerTbl.TotalWidth = 500;
        footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        PdfPCell cell = new PdfPCell(footer);
        cell.Border = 0;
        cell.PaddingRight = 10;
        footerTbl.AddCell(cell);
        
        footerTbl.WriteSelectedRows(0, -1, 420, 30, writer.DirectContent);

    }


}
