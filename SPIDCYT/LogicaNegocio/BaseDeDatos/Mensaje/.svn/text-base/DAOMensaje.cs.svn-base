using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

 public sealed partial class DAOMensaje
{

     private static Mensaje Transformar(DataRow fila)
     {
         if (fila == null) { return null; }

         Mensaje mensaje = new Mensaje();

         mensaje.ID = Convert.ToInt32(fila["idMensaje"]);
         mensaje.DESCRIPCION = Convert.ToString(fila["descripcion"]);
         mensaje.TABLERO = Convert.ToInt32(fila["idTablero"]);

         return mensaje;
     }
}
