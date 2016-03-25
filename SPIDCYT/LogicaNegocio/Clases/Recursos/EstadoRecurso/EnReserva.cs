using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa el estado de los recursos que se encuentran reservados por un proyecto.
/// </summary>
public class EnReserva: IEstadoRecurso
{
    public EnReserva()
    {
         this.ID = 5;
        this.NOMBRE = "En Reserva";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Devuelve true en caso de estar reservado</returns>
    public static  bool estaReservado() { return true; }

    /// <summary>
    /// Permite asignar un recurso a proyecto que lo tiene reservado.
    /// </summary>
    /// <param name="recursoEnProyecto"></param>
    /// <param name="fechaDesde"></param>
    public override void asignarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaDesde)
    {
        recursoEnProyecto.RECURSO.ESTADOACTUAL = DAOEstadoRecurso.get("Ocupado"); 
        recursoEnProyecto.FECHADESDE = fechaDesde;
        DAORecursoEnProyecto.modificarRecursoEnProyecto(recursoEnProyecto, true);
    }
}
