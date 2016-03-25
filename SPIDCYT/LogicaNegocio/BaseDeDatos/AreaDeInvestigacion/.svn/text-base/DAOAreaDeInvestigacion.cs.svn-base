using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public partial class DAOAreaDeInvestigacion
    {

    public static AreaDeInvestigacion Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        AreaDeInvestigacion areaDeInvestigacion = new AreaDeInvestigacion();

        areaDeInvestigacion.ID = Convert.ToInt32(fila["idAreaDeInvestigacion"]);
        areaDeInvestigacion.NOMBRE = Convert.ToString(fila["nombre"]);

        return areaDeInvestigacion;
    }

    }
