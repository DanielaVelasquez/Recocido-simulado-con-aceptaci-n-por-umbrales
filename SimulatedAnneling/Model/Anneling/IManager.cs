using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnneling.Model.Anneling
{
    /// <summary>
    /// Modela el administrador del problema, encargado de proveer
    /// información general asociada al problema a resolver por ejemplo
    /// generar una solución aletoria inicial
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Crea una solución aletoria del problema
        /// </summary>
        /// <param name="random">Objeto crea de forma aletoria una solución, iniciado con una semilla</param>
        /// <returns>Una solución aletoria asociada al problema</returns>
        ISolution getRamdomSolution(Random random);
    }
}
