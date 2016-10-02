﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatedAnneling.Model.TravelerSalesmanProblem;
using System.Collections;
using SimulatedAnneling.Model.Anneling;
using System.Threading;
using System.IO;
namespace SimulatedAnneling.Controller
{
    public class TravelerSalesmanProblem
    {
        /**-------------------------------------------------------------------------------------------
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Nombre servidor de la base de datos
        ///</summary>
        private const String SERVER = "localhost";
        /// <summary>
        /// Usuario de acceso a la base de datos
        /// </summary>
        private const String USER_ID = "root";
        /// <summary>
        /// Contaseña de acceso a la base de datos
        /// </summary>
        private const String PASSWORD = "root";
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        private const String DATA_BASE = "tsp";

        /// <summary>
        /// Factor de enfriamiento del sistema, determina que tan rápido o lento
        /// la temperatura disminuyendo
        /// </summary>
        private const double COOLING_FACTOR = 0.8575;

        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private const double BATCH_SIZE = 500;

        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private const double MAX_ITERATION_BATCH = BATCH_SIZE * 300;

        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private const double EP_INITIAL_TEMPERATURE = 0.045;


        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private const double E_SIMULATED_ANNELING = 0.79;

        /// <summary>
        /// Valor de la temperatura inicial para el calculo de la temperatura inicial,
        /// segun el problema
        /// </summary>
        private const double INITIAL_TEMPERATURE = 8;

        /// <summary>
        /// Cero virtual para ayudar a detener el algoritmo de
        /// busqueda binaria, al preguntar por la diferencia
        /// de sus temperaturas
        /// </summary>
        private const double ET_BINARY_SEARCH = 0.43;
        
        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private const double EP_BINARY_SEARCH = 0.025;
        /// <summary>
        /// Cero virtual para el algoritmo de recocido simulado
        /// </summary>
        private const double EP_SIMULATED_ANNELING = 0.3458;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private const double N_PERCENTAGE_ACCEPTED = 150;
        /// <summary>
        /// Porcentaje de soluciones aceptadas que se desea tener para calcular
        /// la solución inicial
        /// </summary>
        private const double ACCEPTED_SOLUTIONS = 0.95;

        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Objeto contiene toda la información de las ciudades
        ///</summary>
        private TourManager tourManager;

        /// <summary>
        /// Referencia única del controlador
        /// </summary>
        private static TravelerSalesmanProblem singleton = null;
        /// <summary>
        /// Simulación que se está realizando
        /// </summary>
        private SimulatedAnneling.Model.Anneling.Simulation simulation;


        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        private TravelerSalesmanProblem()
        {
            tourManager = new TourManager(SERVER, USER_ID, PASSWORD, DATA_BASE);
        }
        /// <summary>
        /// Obtiene la instancia única de la clase
        /// </summary>
        /// <returns>instancia única de la clase</returns>
        public static TravelerSalesmanProblem getInstance()
        {
            if (singleton == null)
                singleton = new TravelerSalesmanProblem();
            return singleton;
        }
        /// <summary>
        /// Entrega ciudades participantes en el problema
        /// </summary>
        /// <returns>ciudades del problema tsp</returns>
        public ArrayList getCities()
        {
            return tourManager.getCities();
        }
        /// <summary>
        /// Encuentra una ciudad según su posición a partir de todas las ciudades disponibles del problema
        /// </summary>
        /// <param name="latitude">Latitud de la ciudad a buscar</param>
        /// <param name="longitude">Longitud de la ciudad a buscar</param>
        /// <returns></returns>
        public City findCityBy(double latitude, double longitude)
        {
            return tourManager.findCityBy(latitude, longitude, getCities());
        }
        /// <summary>
        /// Cuenta la cantidad de ciudades participantes en el problema
        /// </summary>
        /// <returns>cantidad ciudades problema</returns>
        public int countCities()
        {
            return tourManager.countCities();
        }

        public void simulate()
        {
            Thread thread = new Thread(simulating);
            thread.Start();
        }
        public void set_simulation(int seed, int cities)
        {
            simulation = new Simulation(seed, COOLING_FACTOR, BATCH_SIZE, MAX_ITERATION_BATCH, EP_INITIAL_TEMPERATURE, E_SIMULATED_ANNELING, INITIAL_TEMPERATURE, ET_BINARY_SEARCH, EP_BINARY_SEARCH, N_PERCENTAGE_ACCEPTED, ACCEPTED_SOLUTIONS,EP_SIMULATED_ANNELING, tourManager);
            tourManager.setCitiesSimulation(cities);
        }
        private void simulating()
        {
            simulation.simulate();
        }
        public Simulation getSimulation()
        {
            return simulation;
        }

        
    }
}
