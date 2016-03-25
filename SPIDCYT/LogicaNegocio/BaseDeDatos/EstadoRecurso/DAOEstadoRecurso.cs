using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOEstadoRecurso
{
    private static IEstadoRecurso Transformar(DataRow fila)
    {
        IEstadoRecurso estadoRecurso = new Disponible();
        switch (Convert.ToString(fila["nombre"]))
        {
            case "Disponible":
                estadoRecurso = new Disponible();
                break;
            case "De Baja":
                estadoRecurso = new DeBaja();
                break;
            case "Ocupado":
                estadoRecurso = new Ocupado();
                break;
            case "En Reserva ":
                estadoRecurso = new EnReserva();
                break;
            case "Con Demora ":
                estadoRecurso = new ConDemora();
                break;
            case "Ocupado Con Reserva":
                estadoRecurso = new OcupadoConReserva();
                break;
 
        }

        estadoRecurso.ID = Convert.ToInt32(fila["idEstadoRecurso"]);
        estadoRecurso.NOMBRE = Convert.ToString(fila["nombre"]);
        estadoRecurso.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return estadoRecurso;
    }
    }
