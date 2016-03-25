using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOPresupuesto
{

    private static Presupuesto Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Presupuesto presupuesto = new Presupuesto();

        presupuesto.ID = Convert.ToInt32(fila["idPresupuesto"]);
        presupuesto.FECHAASIGNACION = Convert.ToDateTime(fila["fechaAsignacion"], new CultureInfo("es-ES"));
        presupuesto.FECHAVENCIMIENTO = Convert.ToDateTime(fila["fechaVencimiento"], new CultureInfo("es-ES"));
        presupuesto.MONTO = Convert.ToDouble(fila["monto"]);
        presupuesto.GASTOS = listarGastosDePresupuesto(presupuesto.ID);
        
        return presupuesto;
    }

    




    
}
