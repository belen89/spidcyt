using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa el estado de los recursos cuando no están siendo utlizados
/// </summary>
public class Disponible: IEstadoRecurso
{
    public Disponible()
    {
        this.ID = 1;
        this.NOMBRE = "Disponible";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Devuelve true en caso de que estñe disponible </returns>
    public static  bool estaDisponible() { return true; }

    /// <summary>
    /// Permite reservar un recurso disponible
    /// </summary>
    /// <param name="recurso"></param>
    /// <param name="fechaDesde"></param>
    /// <param name="diasEstimadosDeUSo"></param>
    /// <param name="idProyecto"></param>
    public override  void pedirRecurso(Recurso recurso, DateTime fechaDesde, int diasEstimadosDeUSo, int idProyecto) 
    {
        RecursoEnProyecto nuevoRecursoEnProyecto = new RecursoEnProyecto();
        
        nuevoRecursoEnProyecto.FECHADESDE = fechaDesde;
        nuevoRecursoEnProyecto.DIASESTIMADOSDEUSO = diasEstimadosDeUSo;
        nuevoRecursoEnProyecto.FECHAPEDIDO = DateTime.Today;
        recurso.ESTADOACTUAL = DAOEstadoRecurso.get("En Reserva");
        nuevoRecursoEnProyecto.RECURSO = recurso;
        DAORecursoEnProyecto.insertarRecursoEnProyecto(nuevoRecursoEnProyecto, idProyecto);
    }
}
