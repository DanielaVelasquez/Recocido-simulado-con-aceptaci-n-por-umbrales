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
        private const int INITIAL_TEMPERATURE = 8;
        
        /// <summary>
        /// Cero virtual para ayudar a detener el algoritmo de
        /// busqueda binaria, al preguntar por la diferencia
        /// de sus temperaturas
        /// </summary>
        private const double ET = 0.036;

        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private const double EACCEPTED = 0.0025;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private const int N = 150;
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Temperatura permite explorar soluciones fuera de un mínimo local
        /// </summary>
        private double temperature;
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
        private double calculateLot(ISolution solution)
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
        private Boolean isAccepted(ISolution neighbour,ISolution solution, double temp)
        {
            return neighbour.calculateCostFunction() <= solution.calculateCostFunction() + temp;
        }
        /// <summary>
        /// Realiza el recocido simulado a partir de una solución inicial, hasta encontrar
        /// el equilibrio térmico
        /// </summary>
        /// <param name="solution">solución inicial para la simulación</param>
        private void simulatedAnneling(ISolution solution)
        {
            double p = double.MaxValue;
            //Determina si aún se están generando soluciones en un lote
            Boolean isWorking = true;
            while(temperature>E && isWorking)
            {
                double p1 = 0;
                while(Math.Abs(p-p1)>EP)
                {
                    double temp = calculateLot(solution);
                    //Si el último lote terminó
                    if (didLastLotEnd())
                    {
                        p1 = p;
                        p = temp;
                        solution = getLastLot().getBest();
                        //Si es la mejor solucion se guarda
                        if (isAccepted(solution, bestSolution, temperature))
                            bestSolution = solution;
                    }
                    else
                        //Ya no se están produciendo nuevas soluciones, se para el 
                        //algoritmo
                        isWorking = false;

                }
                temperature = COOLING_FACTOR*temperature;
            }
        }
        /// <summary>
        /// Retorna el último lote generado en caso de que exista
        /// </summary>
        /// <returns>último lote generado, en caso de no haber lotes retorna null</returns>
        private Lot getLastLot()
        {
            //Obtiene indice del ultimo lote en la lista de lotes
            int lastIndex = lots.Count - 1;
            if (lastIndex>=0)
                return (Lot)lots[lastIndex];
            return null;
        }
        /// <summary>
        /// Retora si el ultimo lote se generó completo o no
        /// </summary>
        /// <returns>verdadero si el lote se genero completo, falso en caso contrario</returns>
        private Boolean didLastLotEnd()
        {
            Lot lot = getLastLot();
            return lot.isFinished();
        }
        private double initialTemperature(ISolution s,double temp,double p)
        {
            double p1 = perAceppted(s, temp);
            double temp1, temp2;
            if (Math.Abs(p - p1) <= EP)
                return temp;
            if(p1<p)
            {
                while(p1<p)
                {
                    temp = 2 * temp;
                    p1 = perAceppted(s, temp);
                }
                temp1 = temp / 2;
                temp2 = temp;
            }
            else
            {
                while(p1>p)
                {
                    temp = temp / 2;
                    p1 = perAceppted(s, temp);
                }
                temp1 = temp;
                temp2 = 2 * temp;
            }
            return binarySearch(s, temp1, temp2, p);
        }
        /// <summary>
        /// Obtiene el porcentaje de soluciones aceptadas que se generaron
        /// a partir de una solución inicial con una temperatura
        /// </summary>
        /// <param name="solution">solución inicial para recorrer el espacio de soluciones</param>
        /// <param name="temperature">temperatura inicial permite conocer el porcentaje de soluciones promedio para dicha  temperatura</param>
        /// <returns>porcentaje de soluciones aceptadas para una temperatura inicial</returns>
        private double perAceppted(ISolution solution,double temperature)
        {
            //Cantidad de soluciones aceptadas
            int accepted = 0;
            for(int i = 0; i<N; i++)
            {
                ISolution neighbour = solution.getNeighbour(random);
                if (isAccepted(neighbour, solution, temperature))
                    accepted++;
                solution = neighbour;
            }
            return accepted / N;
        }
        /// <summary>
        /// Realiza busqueda binaria para encontrar una temperatura media entre 
        /// las dos temperaturas dadas
        /// </summary>
        /// <param name="s">solucion inicial</param>
        /// <param name="temp1">primera temperatura</param>
        /// <param name="temp2">segunda temperatura</param>
        /// <param name="accepted">porcentaje de soluciones que se van a aceptar</param>
        /// <returns></returns>
        private double binarySearch(ISolution s,double temp1,double temp2,double accepted)
        {
            double average = (temp1 + temp2) / 2;
            if (temp2 - temp1 < ET)
                return average;
            double accepted1 = perAceppted(s, average);
            if (Math.Abs(accepted - accepted1)<EACCEPTED)
                return average;
            if (accepted1 > accepted)
                return binarySearch(s, temp1, average, accepted);
            else
                return binarySearch(s, average, temp2, accepted);
        }
    }
}
