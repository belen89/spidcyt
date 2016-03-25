using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOTipoBecario
    {
    private static TipoBecario Transformar(DataRow fila)
    {
        TipoBecario tipoBecario = new TipoBecario();

        tipoBecario.ID = Convert.ToInt32(fila["idTipoBecario"]);
        tipoBecario.NOMBRE = Convert.ToString(fila["nombre"]);
        tipoBecario.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        
        return tipoBecario;
    }
    }
