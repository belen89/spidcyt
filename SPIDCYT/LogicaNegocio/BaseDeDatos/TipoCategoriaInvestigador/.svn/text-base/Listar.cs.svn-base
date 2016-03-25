using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public sealed partial class DAOTipoCategoriaInvestigador
{
        public static TipoCategoriaInvestigador get(int idTipoCategoriaInvestigador)
        {
            SqlCommand comando = new SqlCommand();
            Proyecto proyecto = new Proyecto();

            comando.Parameters.AddWithValue("@idTipoCategoriaInvestigador", idTipoCategoriaInvestigador);
            comando.CommandText = "SELECT * FROM TipoCategoriaInvestigador WHERE idTipoCategoriaInvestigador = @idTipoCategoriaInvestigador";
            comando.CommandType = CommandType.Text;
            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return null; }
            return Transformar(tabla.Rows[0]);
        }

        public static List<TipoCategoriaInvestigador> listarTiposCategoriaInvestigador()
        {
            List<TipoCategoriaInvestigador> tipoCategoriasInvestigador = new List<TipoCategoriaInvestigador>();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM TipoCategoriaInvestigador";
            comando.CommandType = CommandType.Text;

            DataTable tabla = Conexion.consultar(comando);
            if (tabla.Rows.Count == 0) { return null; }

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tipoCategoriasInvestigador.Add(Transformar(tabla.Rows[i]));
            }

            return tipoCategoriasInvestigador;
        }


  }

