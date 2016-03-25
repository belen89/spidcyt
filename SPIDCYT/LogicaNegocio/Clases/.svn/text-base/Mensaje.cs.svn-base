using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa mensajes dejados por los usuarios que se reflejan en el tablero de un perfil de proyecto
/// </summary>
    public class Mensaje
    {
        private int id;
        private int tablero;
        private string descripcion;
        private DateTime fechaPublicacion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int TABLERO
        {
            get { return tablero; }
            set { tablero = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Obtiene un mensaje a partir de si ID
        /// </summary>
        /// <param name="idMensaje"></param>
        /// <returns>Mensaje correspondiente</returns>
        public static Mensaje get(int idMensaje)
        {
            return DAOMensaje.get(idMensaje);
        }

        /// <summary>
        /// Elimina un mensaje a partir de su descripción y tablero al cual pertenece
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="idTablero"></param>
        public static void eliminarMensaje(string descripcion, int idTablero)
        {
            DAOMensaje.eliminarMensaje(descripcion, idTablero);
        }

        /// <summary>
        /// Obtiene todos los mensajes de un proyectp
        /// </summary>
        /// <param name="idProyecto"></param>
        /// <returns>Una lista de mensajes correspondientes al proyecto pasado por párametro</returns>
        public static List<Mensaje> listarMensajesPorProyecto(int idProyecto)
        {
            return DAOMensaje.listarMensajesDeProyecto(idProyecto);
        }

        /// <summary>
        /// Inserta un nuevo mensaje a un proyecto
        /// </summary>
        /// <param name="mensaje"></param>
        public static void insertarMensaje(Mensaje mensaje)
        {
            DAOMensaje.insertarMensaje(mensaje);
        }
        /// <summary>
        /// Expira los mensajes de un tablero
        /// </summary>
        /// <param name="idTablero"></param>
        public static void expirarMensajes(int idTablero)
        {
            DAOMensaje.expirarMensajes(idTablero);
        }
    }
