using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOCategoriaInvestigador
{
    public static CategoriaInvestigador get(int idCategoriaInvestigador)
    {
        SqlCommand comando = new SqlCommand();
        Recurso recurso = new Recurso();

        comando.Parameters.AddWithValue("@idCategoriaInvestigador", idCategoriaInvestigador);
        comando.CommandText = "SELECT * FROM CategoriaInvestigador WHERE idCategoriaInvestigador = @idCategoriaInvestigador";

        comando.CommandType = CommandType.Text;
        
        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return null; }
        return Transformar(tabla.Rows[0]);

    }

    public static List<CategoriaInvestigador> obtenerTodasLasCategorias()
    {
        List<CategoriaInvestigador> categoriasInvestigador = new List<CategoriaInvestigador>();
        
        SqlCommand comando = new SqlCommand();
        comando.CommandText = "SELECT * FROM CategoriaInvestigador";
        comando.CommandType = CommandType.Text;

        DataTable tabla = Conexion.consultar(comando);
        if (tabla.Rows.Count == 0) { return null; }

        for (int i = 0; i < tabla.Rows.Count; i++)
        {
            categoriasInvestigador.Add(Transformar(tabla.Rows[i]));
        }
        
        return categoriasInvestigador;

    }

}
