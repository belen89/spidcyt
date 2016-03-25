using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOHito
{

    private static Hito Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Hito hito = new Hito();

        hito.ID = Convert.ToInt32(fila["idHitos"]);
        hito.NOMBRE = Convert.ToString(fila["nombre"]);
        hito.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        hito.ACTUALIZACIONFECHAACTIVIDAD = listarActualizacionFechas(hito.ID);
        if (fila["idproyecto"].ToString() != string.Empty)
            hito.PROYECTO = DAOProyecto.get(Convert.ToInt32(fila["idproyecto"]));
        if (fila["fechaFinReal"].ToString() != string.Empty)
            hito.FECHAFINREAL = Convert.ToDateTime(fila["fechaFinReal"], new CultureInfo("es-ES"));
        return hito;
    }

}
