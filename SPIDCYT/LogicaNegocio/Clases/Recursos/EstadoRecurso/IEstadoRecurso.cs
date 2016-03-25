using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Interfaz para representar el comportamiento de los estados de los recursos de la secretaría. 
/// </summary>
public abstract class IEstadoRecurso
{
    private string nombre;
    private string descripcion;
    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string DESCRIPCION
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public string NOMBRE
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public bool estaReservado() { return false; }
    public bool estaDadoDeBaja() { return false; }
    public bool estaDemorado() { return false; }
    public bool estaOcupado() { return false; }
    public bool estaDisponible() { return false; }
    public bool estaOcupadoConReserva() { return false; }

    public virtual void liberarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaHastaReal) { }
    public virtual void asignarRecurso(RecursoEnProyecto recursoEnProyecto, DateTime fechaDesde) { }
    public virtual void pedirRecurso(Recurso recurso, DateTime fechaDesde, int diasEstimadosDeUSo, int idProyecto) { }


    public static Recurso darDeBaja(Recurso recurso)
    {
        recurso.FECHABAJA = DateTime.Today;
        recurso.ESTADOACTUAL = new DeBaja();
        return recurso;
    }

    public static IEstadoRecurso get(string nombre)
    {
        return DAOEstadoRecurso.get(nombre);
    }
    public static IEstadoRecurso get(int idEstadoRecurso)
    {
        return DAOEstadoRecurso.get(idEstadoRecurso);
    }
   
}
