using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimulatedAnneling.Model.SimulatedAnneling
{
    public class SimulatedAnneling
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
        /// <summary>
        /// Valor de la temperatura inicial para el calculo de la temperatura inicial,
        /// segun el problema
        /// </summary>
        private const int INITIAL_TEMPERATURE = 150;
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
        /// Lotes generados durante la simulación del recocido
        /// </summary>
        private ArrayList lots;
        /// <summary>
        /// Administrador del problema que se desea resolver
        /// </summary>
        private IManager manager;

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/
        /// <summary>
        /// Constructor para el recocido simulado
        /// </summary>
        /// <param name="nSeed">Valor de la semilla para obtener la aletoridad</param>
        public SimulatedAnneling(int nSeed)
        {
            seed = nSeed;
            temperature = INITIAL_TEMPERATURE;
            random = new Random(seed);
            bestSolution = null;
            lots = new ArrayList();
        }
        /// <summary>
        /// Calcula un lote de soluciones dentro del umbral determinado por la temperatura
        /// </summary>
        /// <param name="solution">solución a partir de la cual se va a generar el lote</param>
        /// <returns>Promedio de las soluciones aceptadas</returns>
        private float calculateLot(ISolution solution)
        {
            //Cantidad de vecinos aceptados
            int neighbours_accepted = 0;
            //Suma costos de función de todos los vecinos aceptados
            float costs_functions = 0;
            //Cantidad de iteraciones
            int iterations = 0;
            //Creación de un lote
            Lot lot = new Lot(temperature);
            //Adiciona primera solucion
            lot.addSolution(solution);
            //Se asume como mejor solución a la solución inicial dada
            lot.setBest(solution);
            while(neighbours_accepted < LOT_SIZE && iterations < MAX_ITERATION_LOT)
            {
                ISolution neighbour = solution.getNeighbour(random);
                if (isAccepted(neighbour,solution,temperature))
                {
                    solution = neighbour;
                    neighbours_accepted = neighbours_accepted + 1;
                    costs_functions = costs_functions + neighbour.calculateCostFunction();
                    //Adiciona el vecino aceptado
                    lot.addSolution(neighbour);   
                }
                iterations = iterations + 1;
            }
            //Determina si el lote acabó 
            lot.setIsFinished(neighbours_accepted <= LOT_SIZE);
            //Adiciona el lote al conjunto de lotes del problema
            lots.Add(lot);
            //Se guarda la mejor solución del lote
            lot.setBest(solution);
            return costs_functions / LOT_SIZE;
        }
        /// <summary>
        /// Determina si un vecino es aceptado a partir de la temperatura y la solución 
        /// que se tiene de referencia
        /// </summary>
        /// <param name="neighbour">Vecino que se quiere saber si es aceptado</param>
        /// <param name="solution">Solution de la cual se obtuvo el vecino</param>
        /// <param name="temp">Temperatura en la cual se está evaluando la función de costo</param>
        /// <returns> 
        /// verdadero si la funcion de costo del vecino es menor o igual a la función 
        /// de costo de la solución actual más la temperatura, falso en caso contrario
        /// </returns>
        private Boolean isAccepted(ISolution neighbour,ISolution solution, int temp)
        {
            return neighbour.calculateCostFunction() <= solution.calculateCostFunction() + temp;
        }
        private void simulatedAnneling(ISolution solution)
        {
            float p = float.MaxValue;
            while(temperature>E)
            {
                float p1 = 0;
                while(Math.Abs(p-p1)>EP)
                {
                    float temp = calculateLot(solution);
                    //Verificar si el último lote terminó
                    if(didLastLotEnd())
                    {
                        p1 = p;
                        p = temp;
                    }

                }
            }
        }
        /// <summary>
        /// Retorna el último lote generado en caso de que exista
        /// </summary>
        /// <returns>último lote generado, en caso de no haber lotes retorna null</returns>
        private Lot getLastLot()
        {
            int lastIndex = lots.Count - 1;
            if (lastIndex>=0)
                return (Lot)lots[lastIndex];
            return null;
        }
        private Boolean didLastLotEnd()
        {
            //Obtiene indice del ultimo lote en la lista de lotes
            int lastIndex = lots.Count - 1;
            Lot lot = (Lot) lots[lastIndex];
            return lot.isFinished();

        }
    }
}
