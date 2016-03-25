using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un tipo de categoría de un Proyecto de Investigación:
/// Categorías:
/// # UTN
/// # Con Incentivo
/// # Incubado
/// </summary>
public class TipoProyecto
{

    private int id;
    private string nombre;
    private string descripcion;

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
    public string DESCRIPCION
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    /// <summary>
    /// Determina si es Incubado
    /// </summary>
    /// <returns></returns>
    internal bool esIncubado()
    {
        if (this.NOMBRE == "Incubado")
            return true;
        else
            return false;
    }
    /// <summary>
    /// Determina si es UTN
    /// </summary>
    /// <returns></returns>
    internal bool esUTN()
    {
        if (this.NOMBRE == "UTN")
            return true;
        else
            return false;
    }
    /// <summary>
    /// Determina si es Con Incentivo
    /// </summary>
    /// <returns></returns>
    internal bool esConIncentivo()
    {
        if (this.NOMBRE == "Con Incentivo")
            return true;
        else
            return false;
    }
}