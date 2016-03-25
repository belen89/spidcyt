using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOActividadBecario
{

    private static Hito Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        Hito hito = new Hito();
        hito.ID = Convert.ToInt32(fila["idHitos"]);
        hito.NOMBRE = Convert.ToString(fila["nombre"]);
        hito.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        if (fila["fechaFinReal"].ToString() != string.Empty)
            hito.FECHAFINREAL = Convert.ToDateTime(fila["fechaFinReal"], new CultureInfo("es-ES"));
        if(fila["idBecario"].ToString() != string.Empty)
            hito.BECARIO=DAOBecario.get(Convert.ToInt32(fila["idBecario"]));
        if(fila["idproyecto"].ToString() != string.Empty)
            hito.PROYECTO=DAOProyecto.get(Convert.ToInt32(fila["idproyecto"]));
        hito.ACTUALIZACIONFECHAACTIVIDAD = listarActualizacionFechas(hito.ID);
        return hito;
    }

}
