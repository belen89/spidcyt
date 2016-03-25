using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAORequerimientosBecario
{
    private static RequerimientosBecario Transformar(DataRow fila)
    {
        RequerimientosBecario requerimientosBecario = new RequerimientosBecario();

        requerimientosBecario.ID = Convert.ToInt32(fila["idRequerimientosBecario"]);
        requerimientosBecario.PROYECTO = DAOProyecto.get(Convert.ToInt32(fila["idProyecto"]));
        requerimientosBecario.NOMBREPERFIL = Convert.ToString(fila["nombrePerfil"]);
        requerimientosBecario.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        requerimientosBecario.HABILIDADESTECNICAS = Convert.ToString(fila["habilidadesTecnicas"]);
        requerimientosBecario.FECHAPUBLICACION = Convert.ToDateTime(fila["fechaPublicacion"], new CultureInfo("es-ES"));
        return requerimientosBecario;
    }
}
