using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa requerimientos para la postulación de un becario
/// </summary>
   public class RequerimientosBecario
    {
        private int id;
        private string descripcion;
        private string nombrePerfil;
        private Proyecto proyecto;
        private string habilidadesTecnicas;
        private DateTime fechaPublicacion;

        public DateTime FECHAPUBLICACION
        {
            get { return fechaPublicacion; }
            set { fechaPublicacion = value; }
        }

        public string HABILIDADESTECNICAS
        {
            get { return habilidadesTecnicas; }
            set { habilidadesTecnicas = value; }
        } 

        public Proyecto PROYECTO
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        public string NOMBREPERFIL
        {
            get { return nombrePerfil; }
            set { nombrePerfil = value; }
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
       /// <summary>
       /// Crea un nuevo requerimiento de becario
       /// </summary>
       /// <param name="requerimientosBecario"></param>
        public static void insertarRequerimientosBecario(RequerimientosBecario requerimientosBecario)
        {
            DAORequerimientosBecario.insertarRequerimientosBecario(requerimientosBecario);
        }
       /// <summary>
       /// Obtiene un Requerimiento de becario
       /// </summary>
       /// <param name="idRequerimientosBecario"></param>
       /// <returns></returns>
        public static RequerimientosBecario get(int idRequerimientosBecario)
        {
            return DAORequerimientosBecario.get(idRequerimientosBecario);
        }
       /// <summary>
       /// Elimina un requerimiento de becario
       /// </summary>
       /// <param name="idRequerimientosBecario"></param>
        public static void eliminarRequerimientosBecario(int idRequerimientosBecario)
        {
            DAORequerimientosBecario.eliminarRequerimientosBecario(idRequerimientosBecario);
        }
       /// <summary>
       /// Edita un requerimiento de becario
       /// </summary>
       /// <param name="requerimientosBecario"></param>
        public static void actualizarRequerimientosBecario(RequerimientosBecario requerimientosBecario)
        {
            DAORequerimientosBecario.actualizarRequerimientosBecario(requerimientosBecario);
        }
    }
