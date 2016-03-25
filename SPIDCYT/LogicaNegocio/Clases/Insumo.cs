using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un tipo de gasto, el cual implica elementos comprados por el proyecto para uso propio.
/// </summary>
public class Insumo : Gasto
{
    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="monto">Valor del insumo</param>
    /// <param name="descripcion"></param>
    /// <param name="fecha">Fecha de compra</param>
    public Insumo(double monto, string descripcion, DateTime fecha)
    {
        this.monto = monto;
        this.descripcion = descripcion;
        this.fecha = fecha;
    }

    public Insumo()
    {
        
    }
}

