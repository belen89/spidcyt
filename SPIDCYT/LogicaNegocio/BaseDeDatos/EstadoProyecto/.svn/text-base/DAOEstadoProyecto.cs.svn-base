using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOEstadoProyecto
    {
    private static EstadoProyecto Transformar(DataRow fila)
    {
        EstadoProyecto estadoProyecto = new EstadoProyecto();

        estadoProyecto.ID = Convert.ToInt32(fila["idEstadoProyecto"]);
        estadoProyecto.NOMBRE = Convert.ToString(fila["nombre"]);
        estadoProyecto.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return estadoProyecto;
    }
    }
