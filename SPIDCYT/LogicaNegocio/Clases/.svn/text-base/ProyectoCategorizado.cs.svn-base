using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa una Categoría del Proyecto y su Número de Referencia Asociado.
/// Un Proyecto puede tener categoría NACIONAL, UTN o ser Incubado. 
/// Ejemplo:
/// Con Incentivo -> Nro Referencia: 25/E128
/// UTN -> Nro Referencia: EIINCO773
/// 
/// </summary>
public class ProyectoCategorizado
{
    private string numeroReferencia;
    private TipoProyecto tipoProyecto;

    public TipoProyecto TIPOPROYECTO
    {
        get { return tipoProyecto; }
        set { tipoProyecto = value; }
    }
    public string NUMEROREFERENCIA
    {
        get { return numeroReferencia; }
        set { numeroReferencia = value; }
    }

    /// <summary>
    /// Determina si el Proyecto es Incubado
    /// </summary>
    /// <returns></returns>
    public bool esIncubado()
    {
        if (this.TIPOPROYECTO.esIncubado())
            return true;
        else
            return false;
    }
    /// <summary>
    /// Determina si el Proyecto es UTN
    /// </summary>
    /// <returns></returns>
    public bool esUTN()
    {
        if (this.TIPOPROYECTO.esUTN())
            return true;
        else
            return false;
    }
    /// <summary>
    /// Determina si el Proyecto es Con Incentivo
    /// </summary>
    /// <returns></returns>
    public bool esConIncentivo()
    {
        if (this.TIPOPROYECTO.esConIncentivo())
            return true;
        else
            return false;
    }

}
