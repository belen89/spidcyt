using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa la instancia de un recurso en un proyecto.
/// </summary>
public class RecursoEnProyecto
{
    private int id;
    private Recurso recurso;
    private DateTime fechaPedido;
    private DateTime fechaDesde;
    private int diasEstimadosDeUso;
    private DateTime fechaHastaReal;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    public DateTime FECHAHASTAREAL
    {
        get { return fechaHastaReal; }
        set { fechaHastaReal = value; }
    }

    public int DIASESTIMADOSDEUSO
    {
        get { return diasEstimadosDeUso; }
        set { diasEstimadosDeUso = value; }
    }

    public DateTime FECHADESDE
    {
        get { return fechaDesde; }
        set { fechaDesde = value; }
    }

    public DateTime FECHAPEDIDO
    {
        get { return fechaPedido; }
        set { fechaPedido = value; }
    }

    public Recurso RECURSO
    {
        get { return recurso; }
        set { recurso = value; }
    }

    public static void insertarRecursoEnProyecto(RecursoEnProyecto recursoEnProyecto, int idProyecto)
    {
        DAORecursoEnProyecto.insertarRecursoEnProyecto(recursoEnProyecto, idProyecto);
    }

    public static RecursoEnProyecto get(int idRecursoEnProyecto)
    {
        return DAORecursoEnProyecto.get(idRecursoEnProyecto);
    }

    public int obtenerIdDeMiProyecto()
    {
        return DAORecursoEnProyecto.obtenerIdDeMiProyecto(id);
    }

    /// <summary>
    /// controla todos los recursos y su estado actual, dependiendo sus fechas programadas pasaran a estar demorados
    /// </summary>
    public static void definirDemorados()
    {
        List<Recurso> recursos = DAORecurso.listarTodos(new Ocupado());
        List<RecursoEnProyecto> recursosEnProyecto = DAORecursoEnProyecto.listarTodos();
        try
        {
            foreach (RecursoEnProyecto recurso in recursosEnProyecto)
                if (recurso.RECURSO.ESTADOACTUAL.estaOcupado() || recurso.RECURSO.ESTADOACTUAL.estaOcupadoConReserva())
                    Ocupado.tengoDemora(recurso);
        }
        catch { }
    }
   
}
