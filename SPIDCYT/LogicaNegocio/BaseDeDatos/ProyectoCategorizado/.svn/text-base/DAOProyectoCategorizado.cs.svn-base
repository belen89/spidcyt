using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


public sealed partial class DAOProyectoCategorizado
{
    private static ProyectoCategorizado Transformar(DataRow fila)
    {
        ProyectoCategorizado proyectoCategorizado = new ProyectoCategorizado();

        proyectoCategorizado.NUMEROREFERENCIA = Convert.ToString(fila["numeroResolucion"]);
        proyectoCategorizado.TIPOPROYECTO = DAOTipoProyecto.get(Convert.ToInt32(fila["idTipoProyecto"]));

        return proyectoCategorizado;
    }


    
}

