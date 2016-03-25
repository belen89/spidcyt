using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOTipoProducto
{
    private static TipoProducto Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        TipoProducto tipoProducto = new TipoProducto();

        tipoProducto.ID = Convert.ToInt32(fila["idTipoProducto"]);
        tipoProducto.NOMBRE = Convert.ToString(fila["nombre"]);

        return tipoProducto;
    }
}

