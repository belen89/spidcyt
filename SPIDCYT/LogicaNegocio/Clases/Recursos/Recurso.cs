using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un recurso de tipo inventariable que comparten los proyectos de la secretaría. 
/// </summary>
public class Recurso
{

        private int id;
        private string nombre;
        private DateTime fechaBaja;
        private DateTime fechaAlta;
        private string descripcion;
        private IEstadoRecurso estadoActual;
        private List<HistorialDeRecurso> historial;
        private string tipo;

        public string TIPO
        {
            get { return tipo; }
            set { tipo = value; }
        }

    public List<HistorialDeRecurso> HISTORIAL
        {
            get { return historial; }
            set { historial = value; }
        }

  

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
      

        public DateTime FECHAALTA
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }
        

        public DateTime FECHABAJA
        {
            get { return fechaBaja; }
            set { fechaBaja = value; }
        }
    

        public IEstadoRecurso ESTADOACTUAL
        {
            get { return estadoActual; }
            set { estadoActual = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Property
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    /// <summary>
    /// Actualiza el historial de recurso en caso de pasar a ser utilziado por un proyecto. 
    /// </summary>
    /// <param name="proyecto"></param>
    /// <param name="fechaDesde"></param>
        public void agregarElementoAlHistorial(Proyecto proyecto, DateTime fechaDesde)
        {
            HistorialDeRecurso historial = new HistorialDeRecurso();
            historial.PROYECTO = proyecto;
            historial.FECHADESDE = fechaDesde;
            DAOHistorialDeRecurso.insertarHistorialDeRecurso(historial, this.ID);
        }

    /// <summary>
    /// Agrega un recurso nuevo a la secretaría.
    /// </summary>
    /// <param name="recurso"></param>
        public static void agregarRecurso(Recurso recurso)
        {
            DAORecurso.insertarRecurso(recurso);
        }
    /// <summary>
    /// Actualiza los datos de un recurso. 
    /// </summary>
    /// <param name="recurso"></param>
        public static void modificarRecurso(Recurso recurso)
        {
            DAORecurso.modificarRecurso(recurso);
        }

        public static Recurso get(int idRecurso)
        {
           return DAORecurso.get(idRecurso);
        }

        public static void darDeBajaRecurso(Recurso recurso)
        {
            Recurso recursoDeBaja = DeBaja.darDeBaja(recurso);
            DAORecurso.darDeBajaRecurso(recursoDeBaja);
        }

       
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Proyecto en el cual se encuentra el recurso. </returns>
        public Proyecto miProyectoActual()
        {
            return DAORecurso.miProyectoActual(id);
        }

    

}
