﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        /// <summary>
        /// Valor de la temperatura inicial para el calculo de la temperatura inicial,
        /// segun el problema
        /// </summary>
        public const int INITIAL_TEMPERATURE = 150;

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
        private T bestSolution;
        /// <summary>
        /// Mejor solución generada de un lote
        /// </summary>
        private T bestSolutionLot;
        /// <summary>
        /// Lotes generados durante la simulación del recocido
        /// </summary>
        private ArrayList lots;
        /// <summary>
        /// Administrador del problema que se desea resolver
        /// </summary>
        private IManager<T> manager;

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
            bestSolution = default(T);
            bestSolutionLot = default(T);
            lots = new ArrayList();
        }
        
        private float calculateLot(T solution)
        {
            //Cantidad de vecinos aceptados
            int neighbours_accepted = 0;
            //Suma costos de función de todos los vecinos aceptados
            float costs_functios = 0;
            //Cantidad de iteraciones
            int iterations = 0;

            while(neighbours_accepted < LOT_SIZE && iterations < MAX_ITERATION_LOT)
            {
                T neighbour = solution.getNeighbour(random);
                if (isAccepted(neighbour,solution,temperature)
                {

                }

            }
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
        private Boolean isAccepted(T neighbour,T solution, int temp)
        {
            return neighbour.calculateCostFunction() <= solution.calculateCostFunction() + temp;
        }
    }
}
