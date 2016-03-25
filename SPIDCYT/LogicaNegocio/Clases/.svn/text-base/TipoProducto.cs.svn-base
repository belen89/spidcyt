using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Determina el tipo de Producto
/// Tipos:
/// #Congreso
/// #Patente
/// #Paper
/// #Producto de Hardware/Software
/// #Publicación en Revista
/// #Publicación Libro/Capítulo
/// #Transferencia/// 
/// </summary>
public class TipoProducto
{
            private int id;
            private string nombre;

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

        public static TipoProducto get(int idTipoProducto)
        {
            return DAOTipoProducto.get(idTipoProducto);
        }
}
