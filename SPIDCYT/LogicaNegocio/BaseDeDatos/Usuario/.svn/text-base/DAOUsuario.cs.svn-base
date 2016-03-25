using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOUsuario
{
    private static Usuario Transformar(DataRow fila)
    {
        if (fila == null) { return null; }

        Usuario usuario = new Usuario();

        usuario.NOMBREUSUARIO = Convert.ToString(fila["UserName"]);
        return usuario;
    }

    


}
