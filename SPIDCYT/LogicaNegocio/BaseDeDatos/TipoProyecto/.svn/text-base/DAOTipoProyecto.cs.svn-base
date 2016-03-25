using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOTipoProyecto
{
    private static TipoProyecto Transformar(DataRow fila)
    {
        TipoProyecto tipoProyecto = new TipoProyecto();

        tipoProyecto.ID = Convert.ToInt32(fila["idTipoProyecto"]);
        tipoProyecto.NOMBRE = Convert.ToString(fila["nombre"]);
        tipoProyecto.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return tipoProyecto;
    }
}