using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOHistorialDeRecurso
    {

    private static HistorialDeRecurso Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        HistorialDeRecurso historialDeRecurso = new HistorialDeRecurso();

        historialDeRecurso.ID = Convert.ToInt32(fila["idHistorialRecurso"]);
        historialDeRecurso.FECHADESDE = Convert.ToDateTime(fila["fechaDesde"], new CultureInfo("es-ES"));
        if(fila["fechaHasta"] != DBNull.Value)
            historialDeRecurso.FECHADESDE = Convert.ToDateTime(fila["fechaHasta"], new CultureInfo("es-ES"));
        return historialDeRecurso;    
    }

    }
