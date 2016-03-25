using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa el estado de los recursos que están siendo utilziados por un proyecto. 
/// </summary>
public class Ocupado: IEstadoRecurso
{
    public Ocupado()
    {
        this.ID = 2;
        this.NOMBRE = "Ocupado";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Devuelve true en caso de estar ocupado</returns>
    public static  bool estaOcuado() { return true; }

    /// <summary>
    /// Permite liberar el recurso que estaba siendo utilziado por un proyecto. 
    /// </summary>
    /// <param name="recursoEnProyecto"></param>
    /// <param name="fechaHastaReal"></param>
    public override void liberarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaHastaReal)
    {

        recursoEnProyecto.FECHAHASTAREAL = fechaHastaReal;
        recursoEnProyecto.RECURSO.ESTADOACTUAL = DAOEstadoRecurso.get("Disponible");
        DAORecursoEnProyecto.darDeBajaRecursoEnProyecto(recursoEnProyecto, recursoEnProyecto.obtenerIdDeMiProyecto());
    }

    /// <summary>
    /// Permite reservar un recurso que está siendo utilziado para cuando se desocupe
    /// </summary>
    /// <param name="recurso"></param>
    /// <param name="fechaDesde"></param>
    /// <param name="diasEstimadosDeUSo"></param>
    /// <param name="idProyecto"></param>
    public override void pedirRecurso(Recurso recurso, DateTime fechaDesde, int diasEstimadosDeUSo, int idProyecto)
    {
        RecursoEnProyecto nuevoRecursoEnProyecto = new RecursoEnProyecto();
        
        nuevoRecursoEnProyecto.FECHADESDE = fechaDesde;
        nuevoRecursoEnProyecto.DIASESTIMADOSDEUSO = diasEstimadosDeUSo;
        nuevoRecursoEnProyecto.FECHAPEDIDO = DateTime.Today;
        recurso.ESTADOACTUAL = DAOEstadoRecurso.get("Ocupado Con Reserva");
        nuevoRecursoEnProyecto.RECURSO = recurso;
        DAORecursoEnProyecto.insertarRecursoEnProyecto(nuevoRecursoEnProyecto, idProyecto);
        
    }

    /// <summary>
    /// Permite decidir si un recurso ocupado sigue en fecha de prestamo o ya debería ser devuelto
    /// </summary>
    /// <param name="recursoEnProyecto"></param>
    /// <returns></returns>
    public static  bool tengoDemora(RecursoEnProyecto recursoEnProyecto)
    {
        if (recursoEnProyecto.FECHADESDE.AddDays(recursoEnProyecto.DIASESTIMADOSDEUSO) < DateTime.Today && recursoEnProyecto.FECHAHASTAREAL.ToShortDateString().CompareTo("01/01/0001") ==0 )
        {
            recursoEnProyecto.RECURSO.ESTADOACTUAL = DAOEstadoRecurso.get("Con Demora");
            DAORecursoEnProyecto.modificarRecursoEnProyecto(recursoEnProyecto,false);
            return true;
        }
        return false;
    }
}
