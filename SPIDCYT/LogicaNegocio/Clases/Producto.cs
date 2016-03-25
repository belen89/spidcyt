using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// Representa productos de los proyectos 
/// </summary>
public class Producto
    {
        private int id;
        private string titulo;
        private TipoProducto tipo;
        private string descripcion;
        private string archivo;
        private DateTime fechaPublicacion;
        private string link;

        public string LINK
        {
            get { return link; }
            set { link = value; }
        } 

        public DateTime FECHAPUBLICACION
        {
            get { return fechaPublicacion; }
            set { fechaPublicacion = value; }
        }

        public string TITULO
        {
            get { return titulo; }
            set { titulo = value; }
        }
        

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
   

        public string ARCHIVO
        {
            get { return archivo; }
            set { archivo = value; }
        }

       
        public TipoProducto TIPO
        {
            get { return tipo; }
            set { tipo = value; }
        } 


        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    /// <summary>
    /// Guarda un nuevo producto en un proyecto
    /// </summary>
    /// <param name="producto"></param>
    /// <param name="idProyecto"></param>
    /// <returns></returns>
        public static int guardar(Producto producto, int idProyecto)
        {
            return DAOProducto.insertarProducto(producto, idProyecto);
        }
    /// <summary>
    /// Obtiene un proyecto a partir de un id
    /// </summary>
    /// <param name="idProducto"></param>
    /// <returns>Producto</returns>
        public static Producto get(int idProducto)
        {
            return DAOProducto.get(idProducto);
        }
    /// <summary>
    /// Edita un producto
    /// </summary>
    /// <param name="producto"></param>
        public static void modificarProducto(Producto producto)
        {
            DAOProducto.modificarProducto(producto);
        }
    /// <summary>
    /// Elimina un producto
    /// </summary>
    /// <param name="idProducto"></param>
        public static void eliminarProducto(int idProducto)
        {
            DAOProducto.eliminarProducto(idProducto);
        }
    }
