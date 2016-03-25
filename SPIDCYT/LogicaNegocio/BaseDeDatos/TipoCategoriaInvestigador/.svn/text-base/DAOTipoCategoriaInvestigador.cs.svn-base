using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

public sealed partial class DAOTipoCategoriaInvestigador
{
    private static TipoCategoriaInvestigador Transformar(DataRow fila)
    {
        if (fila == null) { return null; }
        TipoCategoriaInvestigador tipoCategoriaInvestigador = new TipoCategoriaInvestigador();

        tipoCategoriaInvestigador.ID = Convert.ToInt32(fila["idTipoCategoriaInvestigador"]);
        tipoCategoriaInvestigador.NOMBRE = Convert.ToString(fila["nombre"]);
        tipoCategoriaInvestigador.DESCRIPCION = Convert.ToString(fila["descripcion"]);

        return tipoCategoriaInvestigador;
    }

}

