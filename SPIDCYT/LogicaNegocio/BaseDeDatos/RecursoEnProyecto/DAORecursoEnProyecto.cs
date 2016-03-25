using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAORecursoEnProyecto
    {

    private static RecursoEnProyecto Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        RecursoEnProyecto recursoEnProyecto = new RecursoEnProyecto();

        recursoEnProyecto.ID= Convert.ToInt32(fila["idRecursoEnProyecto"]);
        recursoEnProyecto.RECURSO = DAORecurso.get(Convert.ToInt32(fila["idRecurso"]));
        if( fila["fechaPedido"]!= DBNull.Value)
            recursoEnProyecto.FECHAPEDIDO = Convert.ToDateTime(fila["fechaPedido"], new CultureInfo("es-ES"));
        if( fila["fechaDesde"]!= DBNull.Value)
            recursoEnProyecto.FECHADESDE = Convert.ToDateTime(fila["fechaDesde"], new CultureInfo("es-ES"));
        if (fila["fechaHastaReal"] != DBNull.Value)
            recursoEnProyecto.FECHAHASTAREAL = Convert.ToDateTime(fila["fechaHastaReal"], new CultureInfo("es-ES"));
        recursoEnProyecto.DIASESTIMADOSDEUSO = Convert.ToInt32(fila["diasEstimadosDeUso"]);
  
        return recursoEnProyecto;    
    }

    }
