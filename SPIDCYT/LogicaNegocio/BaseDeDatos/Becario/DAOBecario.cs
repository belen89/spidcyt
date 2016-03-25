using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOBecario
    {
    private static Becario Transformar(DataRow fila)
    {
        Becario becario = new Becario();

        becario.ID = Convert.ToInt32(fila["idBecario"]);
        becario.LEGAJO = Convert.ToInt32(fila["legajo"]);
        becario.NOMBRE = Convert.ToString(fila["nombre"]);
        becario.APELLIDO = Convert.ToString(fila["apellido"]);
        becario.MAIL = Convert.ToString(fila["mail"]);
        becario.TELEFONO = Convert.ToString(fila["telefono"]);
        becario.FECHAALTA = Convert.ToDateTime(fila["fechaAlta"], new CultureInfo("es-ES"));
        if (fila["fechaBaja"].ToString() != string.Empty)
            becario.FECHABAJA = Convert.ToDateTime(fila["fechaBaja"], new CultureInfo("es-ES"));
        becario.TIPOBECARIO = DAOTipoBecario.get(Convert.ToInt32(fila["tipoBecario"]));

        return becario;
    }
    }
