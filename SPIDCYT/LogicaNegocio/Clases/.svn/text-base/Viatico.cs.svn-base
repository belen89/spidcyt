using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa un gasto de una persona en concepto de Viáticos
/// </summary>
public class Viatico : Gasto
{
    private List<HistorialEstadoViatico> estados;
    private Persona liquidante;
    private int id;

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public Persona LIQUIDANTE
    {
        get { return liquidante; }
        set { liquidante = value; }
    }

    public List<HistorialEstadoViatico> ESTADOS
    {
        get { return estados; }
        set { estados = value; }
    }

    public Viatico(double monto, string descripcion, DateTime fecha, Persona liquidante)
    {
        this.monto = monto;
        this.descripcion = descripcion;
        this.fecha = fecha;
        this.liquidante = liquidante;
    }

    public Viatico()
    {
        // TODO: Complete member initialization
    }
    /// <summary>
    /// obtiene el estado actual de un Viático
    /// </summary>
    /// <returns></returns>
    public HistorialEstadoViatico obtenerEstadoActual()
    {
        int nroDias = 999999;
        HistorialEstadoViatico actual=null;
        foreach (HistorialEstadoViatico historialEstado in estados)
        {

            if ((historialEstado.FECHADESDE - DateTime.Now).Days < nroDias)
            {
                actual = historialEstado;
            }
        }
        return actual;
    }
}

