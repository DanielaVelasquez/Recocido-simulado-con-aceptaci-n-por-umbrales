using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnneling.Model.SimulatedAnneling
{
    public class SimulatedAnneling<T> where T: ISolution
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Temperatura permite explorar soluciones fuera de un mínimo local
        /// </summary>
        private int temperature;
        /// <summary>
        /// Semilla utilizada para aletoriedad de las soluciones
        /// </summary>
        private int seed;
        /// <summary>
        /// Objeto genera números aletorios con base en la semilla
        /// </summary>
        private Random random;
        /// <summary>
        /// Factor de enfriamiento del sistema, determina que tan rápido o lento
        /// la temperatura disminuyendo
        /// </summary>
        private float coolingFactor;

        

    }
}
