using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

 public sealed partial class DAOMarcadorJSON
{

     private static MarcadorJSON Transformar(DataRow fila)
     {
         if (fila == null) { return null; }

         MarcadorJSON congreso= new MarcadorJSON();

         congreso.ID = Convert.ToInt32(fila["idCongreso"]);
         congreso.DESCRIPCION = Convert.ToString(fila["descripcion"]);
         congreso.NOMBRELUGAR = Convert.ToString(fila["nombreLugar"]);
         congreso.NOMBRECONGRESO = Convert.ToString(fila["nombreCongreso"]);
         congreso.LINK = Convert.ToString(fila["link"]);
         congreso.LAT= Convert.ToDecimal(fila["lat"]);
         congreso.LNG = Convert.ToDecimal(fila["lng"]);
         congreso.FECHADESDE = Convert.ToDateTime(fila["fechaDesde"], new CultureInfo("es-ES")).ToShortDateString();
         congreso.FECHAHASTA = Convert.ToDateTime(fila["fechaHasta"], new CultureInfo("es-ES")).ToShortDateString();
         return congreso;
     }
}
