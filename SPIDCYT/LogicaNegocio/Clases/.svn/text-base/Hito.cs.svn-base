using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa Hitos Importantes en cada Proecto de Investigación.
/// Permite hacer estimaciones de Tareas y controlar el avance del Proyecto.
/// </summary>
    public class Hito
    {
        private int id;        
        private string nombre;
        private string descripcion;
        private DateTime fechaEstimada;
        private DateTime fechaFinReal;
        private Becario becario;
        private Proyecto proyecto;
        private List<DateTime> actualizacionFechaActividad;

        public List<DateTime> ACTUALIZACIONFECHAACTIVIDAD
        {
            get { return actualizacionFechaActividad; }
            set { actualizacionFechaActividad = value; }
        }

        public Proyecto PROYECTO
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        public Becario BECARIO
        {
            get { return becario; }
            set { becario = value; }
        }

        public DateTime FECHAFINREAL
        {
            get { return fechaFinReal; }
            set { fechaFinReal = value; }
        }

        public DateTime FECHAESTIMADA
        {
            get { return fechaEstimada; }
            set { fechaEstimada = value; }
        }

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
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
        /***************************Hito para Proyecto**********************************/
        /// <summary>
        /// Guarda un hito en la Base de Datos
        /// </summary>
        /// <param name="hito"></param>
        /// <param name="idProyecto"></param>
        public static void guardarHito(Hito hito, int idProyecto)
        {
            DAOHito.insertarHito(hito, idProyecto);
        }
        /// <summary>
        /// Elimina un Hito de la Base de Datos
        /// </summary>
        /// <param name="idHito"></param>
        public static void eliminarHito(int idHito)
        {
            DAOHito.eliminarHito(idHito);
        }
        /// <summary>
        /// Modifica un Hito de la Base de Datos
        /// </summary>
        /// <param name="hito"></param>
        public static void modificarHito(Hito hito)
        {
            DAOHito.modificarHito(hito);
        }
        /// <summary>
        /// Método para obtener un Hito de la Base de Datos
        /// </summary>
        /// <param name="idHito"></param>
        /// <returns></returns>
        public static Hito get(int idHito)
        {
            return DAOHito.get(idHito); 
        }
        /// <summary>
        /// Método para finalizar un Hito para un Proyecto Dado.
        /// </summary>
        /// <param name="hito"></param>
        public static void finalizarHitoProyecto(Hito hito)
        {
            DAOHito.finalizarHito(hito);
        }

        /**************************Hito para becario****************************/
        /// <summary>
        /// Método utilizado para obtener un Hito a ser cargado en las Actividades de Becario.
        /// </summary>
        /// <param name="idHito"></param>
        /// <returns></returns>
        public static Hito getActividadBecario(int idHito)
        {
            return DAOActividadBecario.get(idHito);
        }
        /// <summary>
        /// Método para insertar actividades de un Becario que luego serán recuperadas
        /// a la hora de hacer los informes de seguimiento.
        /// </summary>
        /// <param name="hito"></param>
        public static void insertarActividadBecario(Hito hito)
        {
            DAOActividadBecario.insertarHito(hito);
        }

        /// <summary>
        /// Actualiza una determinada actividad del becario pasada por parámetro.
        /// </summary>
        /// <param name="hito"></param>
        public static void actualizarActividadBecario(Hito hito)
        {
            DAOActividadBecario.modificarHito(hito);
        }

        /// <summary>
        /// Finaliza una actividad de un Becario con la Fecha Actual
        /// </summary>
        /// <param name="hito"></param>
        public static void finalizarActividadBecario(Hito hito)
        {
            DAOActividadBecario.finalizarHito(hito);
        }

        /// <summary>
        /// Borra una actividad específica de la Base de Datos
        /// </summary>
        /// <param name="idHito"></param>
        public static void borrarActividadBecario(int idHito)
        {
            DAOActividadBecario.borrarActividadBecario(idHito);
        }

        /// <summary>
        /// Método que valida que la fecha de la actividad se encuentre entre el rango
        /// de duración del proyecto en el cual se desarrolló.
        /// </summary>
        /// <param name="fechaActvidad"></param>
        /// <param name="idProyecto"></param>
        /// <param name="idBecario"></param>
        /// <returns></returns>
        public static bool validarRangoDeFecha(DateTime fechaActvidad, int idProyecto, int idBecario)
        {
            return DAOActividadBecario.validarRangoDeFecha(fechaActvidad, idProyecto, idBecario);
        }
    }

