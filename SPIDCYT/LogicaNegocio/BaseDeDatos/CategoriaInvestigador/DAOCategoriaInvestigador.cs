using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOCategoriaInvestigador
{
    private static CategoriaInvestigador Transformar(DataRow fila)
    {
        CategoriaInvestigador categoriaInvestigador = new CategoriaInvestigador();

        categoriaInvestigador.ID = Convert.ToInt32(fila["idCategoriaInvestigador"]);
        categoriaInvestigador.TIPO = DAOTipoCategoriaInvestigador.get(Convert.ToInt32(fila["tipo"]));
        categoriaInvestigador.NOMBRE = Convert.ToString(fila["nombre"]);
        categoriaInvestigador.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return categoriaInvestigador;
    }
}

