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
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Factor de enfriamiento del sistema, determina que tan rápido o lento
        /// la temperatura disminuyendo
        /// </summary>
        private const double COOLING_FACTOR = 0.65432;
        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private const int LOT_SIZE = 100;
        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private const int MAX_ITERATION_LOT = LOT_SIZE * 300;   
        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private const double EP = 0.025;
        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private const double E = 0.015;

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
        /// Mejor solución encontrada del problema 
        /// </summary>
        private ISolution bestSolution;
        /// <summary>
        /// Mejor solución generada de un lote
        /// </summary>
        private ISolution bestSolutionLot;

        

    }
}
