using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOProducto
    {

    private static Producto Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Producto producto = new Producto();

        producto.ID = Convert.ToInt32(fila["idProducto"]);
        producto.TITULO = Convert.ToString(fila["titulo"]);
        producto.DESCRIPCION = Convert.ToString(fila["descripcion"]);
        producto.ARCHIVO = Convert.ToString(fila["archivo"]);
        producto.TIPO= DAOTipoProducto.get(Convert.ToInt32(fila["tipo"]));
        producto.FECHAPUBLICACION = Convert.ToDateTime(fila["fechaPublicacion"], new CultureInfo("es-ES"));
        if((fila["link"]).ToString() != string.Empty)
            producto.LINK = Convert.ToString(fila["link"]);
        return producto;    
    }

    }
