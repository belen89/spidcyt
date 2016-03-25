using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Clase que representa el estado de los recursos que se encuentran en fecha de devolución, pero todavía no han sido devueltos. 
/// </summary>
public class ConDemora: IEstadoRecurso
{
    public ConDemora()
    {
        this.ID = 3;
        this.NOMBRE = "Con Demora";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Verdadero si está demorado</returns>
    public static bool estaDemorado() { return true;  }

    /// <summary>
    /// Libera el recurso demorado
    /// </summary>
    /// <param name="recursoEnProyecto"></param>
    /// <param name="fechaHastaReal"></param>
    public static  void liberarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaHastaReal) {

        recursoEnProyecto.FECHAHASTAREAL = fechaHastaReal;
        recursoEnProyecto.RECURSO.ESTADOACTUAL = DAOEstadoRecurso.get("Disponible");
        DAORecursoEnProyecto.darDeBajaRecursoEnProyecto(recursoEnProyecto, recursoEnProyecto.obtenerIdDeMiProyecto());
    }
    /// <summary>
    /// Método que pide permite reservar recursos demorados
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
}
