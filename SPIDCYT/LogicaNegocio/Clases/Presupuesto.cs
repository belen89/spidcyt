using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// Representa el monto monetario que tiene disponible un proyecto
/// </summary>
public class Presupuesto
{
    private double monto;
    private DateTime fechaAsignacion;
    private DateTime fechaVencimiento;
    private List<Gasto> gastos;
    private int id;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="monto"></param>
    /// <param name="fechaVencimiento"></param>
    /// <param name="fechaAsignacion"></param>
    public Presupuesto(double monto, DateTime fechaVencimiento, DateTime fechaAsignacion)
    {
        this.monto = monto;
        this.fechaVencimiento = fechaVencimiento;
        this.fechaAsignacion = fechaAsignacion;
    }

    public Presupuesto()
    {
        // TODO: Complete member initialization
    }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public double MONTO
    {
        get { return monto; }
        set { monto = value; }
    }

    public DateTime FECHAASIGNACION
    {
        get { return fechaAsignacion; }
        set { fechaAsignacion = value; }
    }

    public DateTime FECHAVENCIMIENTO
    {
        get { return fechaVencimiento; }
        set { fechaVencimiento = value; }
    }

    internal List<Gasto> GASTOS
    {
        get { return gastos; }
        set { gastos = value; }
    }

    /// <summary>
    /// Calcula el monto que tiene disponible para gastar un proyecto, en base de lo que ya haya gastado
    /// </summary>
    /// <returns>Monto disponible</returns>
    public double calcularMontoActual()
    {
        try
        {

            double montoActual = monto;
            if(gastos != null)
            {
            foreach (Gasto gasto in gastos)
            {
                montoActual = montoActual - gasto.MONTO;
            }
            return montoActual;
            }
            else
            {
                return this.MONTO;
            }
        }
        catch { return -9999; }       
        
    }

    /// <summary>
    /// Agrega un presupuesto
    /// </summary>
    /// <param name="idProyecto"></param>
    public void insertarPresupuesto(int idProyecto)
    {
        DAOPresupuesto.insertarPresupuesto(this, idProyecto);
    }
    /// <summary>
    /// Obtiene un presupuesto a partir de un id
    /// </summary>
    /// <param name="idPresupuesto"></param>
    /// <returns>Presupuesto</returns>
    public static Presupuesto get(int idPresupuesto)
    {
        throw new NotImplementedException();
    }
}

