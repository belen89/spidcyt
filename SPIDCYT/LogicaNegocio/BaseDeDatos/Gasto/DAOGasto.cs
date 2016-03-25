using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOGasto
{

    private static Insumo TransformarInsumo(DataRow fila)
    {
        if (fila == null) { return null; }

        Insumo insumo = new Insumo();

        insumo.ID = Convert.ToInt32(fila["idGasto"]);
        insumo.FECHA = Convert.ToDateTime(fila["fecha"], new CultureInfo("es-ES"));
        insumo.MONTO = Convert.ToDouble(fila["monto"]);
        insumo.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        
        return insumo;
    }

    private static Viatico TransformarViatico(DataRow fila)
    {
        if (fila == null) { return null; }

        Viatico viatico = new Viatico();

        viatico.ID = Convert.ToInt32(fila["idGasto"]);
        viatico.FECHA = Convert.ToDateTime(fila["fecha"], new CultureInfo("es-ES"));
        viatico.MONTO = Convert.ToDouble(fila["monto"]);
        viatico.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        viatico.LIQUIDANTE = DAOInvestigador.get(Convert.ToInt32(fila["liquidante"]));

        return viatico;
    }

    public static Insumo Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Insumo insumo = new Insumo();

        insumo.ID = Convert.ToInt32(fila["idGasto"]);
        insumo.FECHA = Convert.ToDateTime(fila["fecha"], new CultureInfo("es-ES"));
        insumo.MONTO = Convert.ToDouble(fila["monto"]);
        insumo.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return insumo;
    }



    
}
