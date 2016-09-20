using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnneling.Model.Anneling
{
    /// <summary>
    /// Modela una solución asociada a un problema
    /// </summary>
    public interface ISolution : ICloneable
    {
        ///<summary>
        ///Calcula la función de costo de una posible solución
        ///@return valor del costo de función
        ///</summary>
        ///<returns>
        ///Función de costo asociada a la solución
        ///</returns>
        double calculateCostFunction();

        ///<summary>
        ///Obtiene un vecino a la solución actual a partir de un elemento random
        ///</summary>
        ///<param name="random">objeto permite aletoriedad iniciado con una semilla</param>
        ///<returns>Solución vecina a la solución actual</returns>
        ISolution getNeighbour(Random random);
    }
}
