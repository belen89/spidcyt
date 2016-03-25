using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa el estado de los recursos que están siendo utilizados por un proyecto pero a su vez están reservados por otro. 
/// </summary>
public class OcupadoConReserva: IEstadoRecurso
{
    public OcupadoConReserva()
    {

        this.ID = 6;
        this.NOMBRE = "Ocupado Con Reserva";
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Devuelve true en caso de si está ocupdo y además tiene reserva. </returns>
    public static bool estaOcupadoConReserva() { return true; }

    /// <summary>
    /// Permite liberar el recurso del proyecto actual usandolo, y pasarlo al proyecto que lo tiene reserbvado
    /// </summary>
    /// <param name="recursoEnProyecto"></param>
    /// <param name="fechaHastaReal"></param>
    public override void liberarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaHastaReal)
    {
        recursoEnProyecto.FECHAHASTAREAL = fechaHastaReal;
        recursoEnProyecto.RECURSO.ESTADOACTUAL = DAOEstadoRecurso.get("En Reserva");
        DAORecursoEnProyecto.darDeBajaRecursoEnProyecto(recursoEnProyecto, recursoEnProyecto.obtenerIdDeMiProyecto());
    } 
}
