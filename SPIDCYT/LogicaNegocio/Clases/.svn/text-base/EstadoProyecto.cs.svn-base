using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa los Distintos Estados por los que puede transitar un Proyecto.
/// Estados: 
/// # En Desarrollo
/// # Finalizado
/// # Cancelado.
/// </summary>
public class EstadoProyecto
    {
        private int id;
        private string nombre;
        private string descripcion;

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
        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Retorna el Objeto Estado según el ID que se le pase por Parámetro.
        /// </summary>
        /// <param name="idEstadoProyecto"></param>
        /// <returns></returns>
        public static EstadoProyecto getEstado(int idEstadoProyecto)
        {
            return DAOEstadoProyecto.get(idEstadoProyecto);
        }

    }

