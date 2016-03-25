using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

public sealed partial class DAOInvestigador
    {
    private static Investigador Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        Investigador investigador = new Investigador();

        investigador.ID = Convert.ToInt32(fila["idInvestigador"]);
        investigador.LEGAJO = Convert.ToInt32(fila["legajo"]);
        investigador.NOMBRE = Convert.ToString(fila["nombre"]);
        investigador.APELLIDO = Convert.ToString(fila["apellido"]);
        investigador.MAIL = Convert.ToString(fila["mail"]);
        investigador.TELEFONO = Convert.ToString(fila["telefono"]);
        investigador.FECHAALTA = Convert.ToDateTime(fila["fechaAlta"], new CultureInfo("es-ES"));

        if (fila["fechaCategorizacionNacional"] != DBNull.Value)
        { investigador.FECHACATEGORIZACIONNACIONAL = Convert.ToDateTime(fila["fechaCategorizacionNacional"], new CultureInfo("es-ES")); }
        if (fila["fechaCategorizacionUTN"] != DBNull.Value)
        { investigador.FECHACATEGORIZACIONUTN = Convert.ToDateTime(fila["fechaCategorizacionUTN"], new CultureInfo("es-ES")); }
        if (fila["fechaBaja"].ToString() != string.Empty)
        { investigador.FECHABAJA = Convert.ToDateTime(fila["fechaBaja"], new CultureInfo("es-ES")); }

        if (fila["categoriaUTN"] != DBNull.Value)
        { investigador.CATEGORIAUTN = DAOCategoriaInvestigador.get(Convert.ToInt32(fila["categoriaUTN"], new CultureInfo("es-ES"))); }

        if (fila["categoriaNacional"] != DBNull.Value)
        { investigador.CATEGORIANACIONAL = DAOCategoriaInvestigador.get(Convert.ToInt32(fila["categoriaNacional"], new CultureInfo("es-ES"))); }

        investigador.HISTORIALCATEGORIA = DAOHistorialCategoria.listarHistorialCategoriaInvestigador(Convert.ToInt32(fila["idInvestigador"], new CultureInfo("es-ES")));

        return investigador;
    }









    
    }
