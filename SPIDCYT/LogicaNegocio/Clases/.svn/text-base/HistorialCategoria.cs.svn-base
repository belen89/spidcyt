using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa una Categoría por la que pasó un Investigador en un Período de Tiempo dado.
/// </summary>
public class HistorialCategoria
{
    private DateTime fechaDesde;    
    private DateTime fechaHasta;
    private CategoriaInvestigador categoriaInvestigador;
    
    public CategoriaInvestigador CATEGORIAINVESTIGADOR
    {
        get { return categoriaInvestigador; }
        set { categoriaInvestigador = value; }
    }
    public DateTime FECHADESDE
    {
        get { return fechaDesde; }
        set { fechaDesde = value; }
    }
    public DateTime FECHAHASTA
    {
        get { return fechaHasta; }
        set { fechaHasta = value; }
    }

    /// <summary>
    /// Determina si la fecha pasada por parámetro está incluida dentro de este Historial de Categorización.
    /// </summary>
    /// <param name="fechaCategorizacion"></param>
    /// <returns></returns>
    internal bool fechaContenidaDentroDeUnaCategorizacion(DateTime fechaCategorizacion)
    {
        //Fecha Desde se valida con >= Porque es Primary Key.
        if (fechaCategorizacion >= FECHADESDE && fechaCategorizacion < FECHAHASTA)
            return true;
        else
            return false;

    }
}
