using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Representa el estado de los recursos que ya no son utilizados por la secretaría.
/// </summary>
public class DeBaja: IEstadoRecurso
{
    
    public DeBaja()
    {
        this.ID = 4;
        this.NOMBRE = "De Baja";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Devuelve true en caso de que esté dado de baja</returns>
    public  static bool estaDadoDeBaja() { return true; }
}
