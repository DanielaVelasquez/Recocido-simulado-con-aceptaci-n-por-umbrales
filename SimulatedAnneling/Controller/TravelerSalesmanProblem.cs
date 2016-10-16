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
using SimulatedAnneling.ObserverPattern;
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
        private const double COOLING_FACTOR = 0.95;

        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private const double BATCH_SIZE = 200;

        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private const double MAX_ITERATION_BATCH = BATCH_SIZE * BATCH_SIZE;

        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private const double EP_INITIAL_TEMPERATURE = 0.086;


        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private const double E_SIMULATED_ANNELING = 0.000023;

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
        private const double EP_SIMULATED_ANNELING = 0.4995;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private const double N_PERCENTAGE_ACCEPTED = 90;
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
        public List<City> getCities()
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
            simulation.simulate();
            /*
            Thread thread = new Thread(simulating);
            thread.Start();*/
        }
        public void set_simulation(int seed, int cities)
        {
            simulation = new Simulation(seed, COOLING_FACTOR, BATCH_SIZE, MAX_ITERATION_BATCH, EP_INITIAL_TEMPERATURE, E_SIMULATED_ANNELING, INITIAL_TEMPERATURE, ET_BINARY_SEARCH, EP_BINARY_SEARCH, N_PERCENTAGE_ACCEPTED, ACCEPTED_SOLUTIONS,EP_SIMULATED_ANNELING, tourManager);
            tourManager.setCitiesSimulation(cities);
        }
        /// <summary>
        /// Lee ids de ciudades en un archivo
        /// </summary>
        /// <param name="file">nombre archivo</param>
        /// <returns>listado de ids</returns>
        private List<int> read_cities(String file)
        {
            try
            {
                List<int> cities_id = new List<int>();


                String[] text = File.ReadAllLines(file);
                foreach (String line in text)
                {
                    String[] split = line.Split(',');
                    foreach (String n in split)
                    {
                        try
                        {
                            cities_id.Add(int.Parse(n));
                        }
                        catch
                        {
                            throw new Exception("File should only contains numbers separate them by ',' ");
                        }

                    }

                }
                return cities_id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        /// <summary>
        /// Encuentra un conjunto de ciudades a partir de sus ids
        /// </summary>
        /// <param name="cities_id">lista ids ciudades</param>
        /// <returns>Ciudades con los ids de la lista</returns>
        private List<City> find_cities(List<int> cities_id)
        {
            if(cities_id.Count > tourManager.get_number_cities_set_simulation())
                throw new Exception("File has more cities than the value configured");
            List<City> c = new List<City>();
            foreach (int id in cities_id)
            {
                City city = tourManager.findCityBy(id, tourManager.getCities());
                if (city != null)
                    c.Add(city);
                else
                    throw new Exception("City with id " + id + " not found");
            }
            return c;
        }
        /// <summary>
        /// Configura la simulación 
        /// </summary>
        /// <param name="seed">semilla para la simulacion</param>
        /// <param name="cities">cantidad de ciudades</param>
        /// <param name="file">nombre archivo para leer ciudades desean escoger</param>
        public void set_simulation(int seed, int cities,String file)
        {

                tourManager.setCitiesSimulation(cities);
                
                List<int> cities_id = read_cities(file);

                List<City> c = find_cities(cities_id);
                tourManager.setCitiesSimulation(c);
                simulation = new Simulation(seed, COOLING_FACTOR, BATCH_SIZE, MAX_ITERATION_BATCH, EP_INITIAL_TEMPERATURE, E_SIMULATED_ANNELING, INITIAL_TEMPERATURE, ET_BINARY_SEARCH, EP_BINARY_SEARCH, N_PERCENTAGE_ACCEPTED, ACCEPTED_SOLUTIONS, EP_SIMULATED_ANNELING, tourManager);
                
            
                
            
        }
        /// <summary>
        /// Configura la simulación a partir de un listado de los ids de las ciudades
        /// </summary>
        /// <param name="seed">semilla</param>
        /// <param name="cities">cantidad de ciudades</param>
        /// <param name="cities_id">listado ids ciudades</param>
        public void set_simulation(int seed, int cities, List<int> cities_id)
        {
            tourManager.setCitiesSimulation(cities);
            List<City> c = find_cities(cities_id);

            tourManager.setCitiesSimulation(c);

            simulation = new Simulation(seed, COOLING_FACTOR, BATCH_SIZE, MAX_ITERATION_BATCH, EP_INITIAL_TEMPERATURE, E_SIMULATED_ANNELING, INITIAL_TEMPERATURE, ET_BINARY_SEARCH, EP_BINARY_SEARCH, N_PERCENTAGE_ACCEPTED, ACCEPTED_SOLUTIONS, EP_SIMULATED_ANNELING, tourManager);
            



        }
        private void simulating()
        {
            simulation.simulate();
        }
        public Simulation getSimulation()
        {
            return simulation;
        }
        public void addObserver(IObserver o)
        {
            simulation.addObserver(o);
        }
        
    }
}
