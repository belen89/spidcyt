using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOHistorialCategoria
{

    private static HistorialCategoria Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        HistorialCategoria historialCategoria = new HistorialCategoria();

        historialCategoria.CATEGORIAINVESTIGADOR= DAOCategoriaInvestigador.get(Convert.ToInt32(fila["categoriaInvestigador"]));
        historialCategoria.FECHADESDE = Convert.ToDateTime(fila["fechaDesde"], new CultureInfo("es-ES"));
        if(fila["fechaHasta"].ToString() != string.Empty)
            historialCategoria.FECHAHASTA = Convert.ToDateTime(fila["fechaHasta"], new CultureInfo("es-ES"));
        return historialCategoria;
    }


}

