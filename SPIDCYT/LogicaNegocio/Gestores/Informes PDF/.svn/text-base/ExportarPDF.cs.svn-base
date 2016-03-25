using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

using System.IO;
using System.Diagnostics;
/// <summary>
/// Clase utilziada para realizar los informes, utliza iTextSharp, libreria que logra exportar contenido html a formato pdf. 
/// </summary>
public class ExportarPDF
{
    /// <summary>
    /// genera un inofrme en pdf a partir de contenido html
    /// </summary>
    /// <param name="infoEnHtml">Estructura HTML que se va a parsear </param>

    public static void generarDocumentoDesdeHTML(string infoEnHtml)
    {
        string file = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
        string html = "<html><body><br /><br />"+infoEnHtml + "</body></html>";
        
        Document document = new Document(PageSize.A4, 80, 50, 30, 65);
       
        
        PdfWriter writer= PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));
        
        document.Open();
        writer.PageEvent = new Footer();
        writer.PageEvent = new Header();

        foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
            document.Add(E);

        document.Close();
        Process prc = new System.Diagnostics.Process();
        prc.StartInfo.FileName = file;
        prc.Start();
    }


    public static void generarDocumento(string titulo, List<string> titulosColumnas, List<string> informacionCeldas, float[] anchoCeldas)
    {
        //Creo el documento PDF y el archivo a escribir.
        string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
        PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
        document.Open();

        //PARRAFO
        Paragraph unParrafo = GenerarParrafo(titulo);
        document.Add(unParrafo);

        //GENERO Y AGREGO SALTO DE LINEA
        document.Add(new Paragraph(" "));

        //GENERO Y AGREGO SALTO DE LINEA
        document.Add(new Paragraph(" "));

        //TABLA
        PdfPTable unaTabla = GenerarTabla(titulosColumnas, informacionCeldas, anchoCeldas);
        document.Add(unaTabla);

        //CIERRO DOCUMENTO
        document.Close();

        //LO EJECUTO
        Process prc = new System.Diagnostics.Process();
        prc.StartInfo.FileName = fileName;
        prc.Start();
    }

    public static Paragraph GenerarParrafo(string titulo)
    {
        //Creamos un nuevo parrafo, por ejemplo el titulo de nuestro reporte
        //Y le damos algunas propiedades.

        Paragraph parrafo = new Paragraph();

        parrafo.Alignment = Element.ALIGN_CENTER;
        parrafo.Font = FontFactory.GetFont("Calibri", 20);
        parrafo.Font.SetStyle(Font.BOLD);
        parrafo.Font.SetStyle(Font.UNDERLINE);

        parrafo.Add(titulo);

        return parrafo;
    }

    public static Image GenerarImagen(Image image)
    {
        //Generamos imágen

        byte[] bytesImagen = new System.Drawing.ImageConverter().ConvertTo(image, typeof(byte[])) as byte[];
        Image imagen = Image.GetInstance(bytesImagen);
        imagen.Alignment = Element.ALIGN_CENTER;

        return imagen;
    }


    public static PdfPTable GenerarTabla(List<string> titulosColumnas, List<string> informacionCeldas, float[] anchoCeldas)
    {


        PdfPTable unaTabla = new PdfPTable(titulosColumnas.Count);

        unaTabla.SetWidthPercentage(anchoCeldas, PageSize.A4);

        //Headers

        foreach (string titulo in titulosColumnas)
        {
            unaTabla.AddCell(new Paragraph(titulo));
        }

        //formato de header
        foreach (PdfPCell celda in unaTabla.Rows[0].GetCells())
        {
            celda.BackgroundColor = BaseColor.LIGHT_GRAY;
            celda.HorizontalAlignment = 1;
            celda.Padding = 3;
        }

        foreach (string informacion in informacionCeldas)
        {
            PdfPCell celda = new PdfPCell(new Paragraph(informacion, FontFactory.GetFont("Calibri", 10)));
            unaTabla.AddCell(celda);
        }

        return unaTabla;

    }
}
