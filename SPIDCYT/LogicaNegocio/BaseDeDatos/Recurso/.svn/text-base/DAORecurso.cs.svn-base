using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAORecurso
    {

    private static Recurso Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Recurso recurso = new Recurso();

        recurso.ID = Convert.ToInt32(fila["idRecurso"]);
        recurso.NOMBRE = Convert.ToString(fila["nombre"]);
        recurso.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        if (fila["fechaAlta"] != DBNull.Value)
            recurso.FECHAALTA = Convert.ToDateTime(fila["fechaAlta"], new CultureInfo("es-ES"));
        if (fila["fechaBaja"] != DBNull.Value)
            recurso.FECHABAJA = Convert.ToDateTime(fila["fechaBaja"], new CultureInfo("es-ES"));
        recurso.ESTADOACTUAL = DAOEstadoRecurso.get(Convert.ToInt32(fila["estadoActual"]));
        recurso.TIPO = Convert.ToString(fila["tipo"]);
        recurso.HISTORIAL = DAOHistorialDeRecurso.listarHistorialDeRecurso(recurso.ID);
        return recurso;    
    }

    }
