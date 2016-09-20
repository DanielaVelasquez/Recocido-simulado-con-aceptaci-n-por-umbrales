using System;
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
        private const double COOLING_FACTOR = 0.61946875;

        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private const int BATCH_SIZE = 100;

        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private const int MAX_ITERATION_BATCH = BATCH_SIZE * 300;

        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private const double EP = 0.8142;


        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private const double E = 0.79;

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
        private const double ET = 0.43;
        
        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private const double EACCEPTED = 0.025;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private const int N = 150;
        /// <summary>
        /// Porcentaje de soluciones aceptadas que se desea tener para calcular
        /// la solución inicial
        /// </summary>
        private const double ACCEPTED_SOLUTIONS = 0.8756;

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
        private SimulatedAnneling.Model.Anneling.SimulatedAnneling simulation;


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

        public void simulate(int seed,int cities)
        {
            simulation = new Model.Anneling.SimulatedAnneling(seed, COOLING_FACTOR, BATCH_SIZE, MAX_ITERATION_BATCH, EP, E, INITIAL_TEMPERATURE, ET, EACCEPTED, N, ACCEPTED_SOLUTIONS, tourManager);
            tourManager.setCitiesSimulation(cities);
            Thread thread = new Thread(simulating);
            thread.Start();
        }
        private void simulating()
        {
            simulation.simulate();
        }
        /*
        public void simulacion(int cities)
        {
            tourManager.setCitiesSimulation(cities);
            string[] lines = { "si", "no" };
            File.AppendAllLines("WriteFile.txt", lines);
            double i = 0.5;
            double f = 0.7;
            double ri = 27.001096637526665;
            double rf = 104.8508596852175;

            double respuesta = binario(ri, rf, i, f,0);

            


         


            
        }
        private double binario(double ri,double rf, double i,double f, int iteracion)
        {
            if(f<i  && iteracion<7)
            {
                if (ri < rf)
                    return f;
                else
                    return i;
            }

            double average = (i + f) / 2;

            double value = calculatevalue(average);

            if (ri > rf)
            {
                return binario(ri, value, i, average,iteracion++);
            }
            else
            {
                return binario(value, rf, average, f,iteracion++);
            }


            

            
        }

        private double calculatevalue(double cooling)
        {
            DateTime inicio = DateTime.Now;
            SimulatedAnneling.Model.Anneling.SimulatedAnneling s = new SimulatedAnneling.Model.Anneling.SimulatedAnneling(3, cooling, BATCH_SIZE, MAX_ITERATION_BATCH, EP, E, INITIAL_TEMPERATURE, ET, EACCEPTED, N, ACCEPTED_SOLUTIONS, tourManager);
            double v = s.simulate().calculateCostFunction();
            DateTime end = DateTime.Now;
            TimeSpan t = end - inicio;

            int seconds = t.Seconds + t.Minutes * 60 + t.Hours * 60 * 60;

            string[] lines = { "Seconds: " + seconds + " cost: " + v };
            File.AppendAllLines("WriteFile.txt", lines);


            return v * 0.55 + seconds * 0.45;
        }
        */

        public Model.Anneling.SimulatedAnneling getSimulation()
        {
            return simulation;

        }
    }
}
