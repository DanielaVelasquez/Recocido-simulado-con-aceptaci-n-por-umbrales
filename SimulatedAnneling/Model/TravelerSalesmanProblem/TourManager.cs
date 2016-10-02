using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SimulatedAnneling.Model.Anneling;
using SimulatedAnneling.DAO;
using SimulatedAnneling.Model.TravelerSalesmanProblem;

namespace SimulatedAnneling.Model.TravelerSalesmanProblem
{
    /// <summary>
    /// Objeto dirige el problema, cononoce todas las ciudades y es capaz de de dar un información sobre todas
    /// ellas, es capaz de generar soluciones aletorias a partir de ellas.
    /// </summary>
    public class TourManager:IManager
    {
        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/
        ///<summary>
        ///Valor por defecto cuando no se han configurado la cantidad de ciudades a simular
        ///</summary>
        private const int CITIES_SIMULATION_NULL = -1;
        ///<summary>
        ///Valor permite representar la no existencia de conexión entre una ciudad y otra
        ///</summary>
        public const double DIAMETER = 12742000;//445970000;//->35//318550000;//->25veces tierr//101936000;//89194000;//22171957741;//22171957741.07997;//double.MaxValue;
        
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Objeto permite acceder a las ciudades registradas y sus respectivas conexiones
        ///</summary>
        private DAOCity cityDAO;
        /// <summary>
        /// Objeto establece conexión con una base de datos sql
        /// </summary>
        private SQLConnection sqlConnection;
        /// <summary>
        /// Conjunto de ciudades del problema
        /// </summary>
        private ArrayList cities;
        /// <summary>
        /// Cantidad de ciudades utilizar para la simulacion
        /// </summary>
        private static double numberCitiesSimulation = CITIES_SIMULATION_NULL;
        /// <summary>
        /// Ciudades quiere aparezcan en la simulación
        /// </summary>
        private ArrayList citiesSimulation;///<summary>
        ///Distancia máxima entre las k ciudades que se van a trabajar en la simulación 
        ///</summary>
        public static double M = -1;

        public static double INFINITE = 10 * M;

        public static double K = -1;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public TourManager(String server, String userId, String password, String database)
        {
            sqlConnection = new SQLConnection(server, userId, password, database);
            cityDAO = new DAOCity(sqlConnection);
            cities = cityDAO.getCities(this);
            numberCitiesSimulation = CITIES_SIMULATION_NULL;
            citiesSimulation = null;
        }
        public static double  get_infinite()
        {
            return DIAMETER * numberCitiesSimulation;
        }
        /// <summary>
        /// Entrega las ciudades involucradas en el problema
        /// </summary>
        /// <returns>ciudades del problema</returns>
        public ArrayList getCities()
        {
            return cities;
        }
        /// <summary>
        /// Cambia el valor de la cantidad de ciudades que se van a simular
        /// </summary>
        /// <param name="n">cantidad de ciudades a simular</param>
        public void setCitiesSimulation(int n)
        {
            //TODO VOLVER NULA LA CANTIDAD DE CIUDADES DESPUES DE CADA SIMULACION
            numberCitiesSimulation = n;
            K = n;
        }

        public ISolution getRamdomSolution(Random random)
        {
            if (numberCitiesSimulation == CITIES_SIMULATION_NULL)
                throw new Exception("You need to set how many cities are going to be use in the simulation");
            else 
            {
                
                //Ciudades parte de la solución
                ArrayList c = new ArrayList();
                //Ciudades que no han sido agregadas a la lista de ciudades solución
                ArrayList copy = (ArrayList)cities.Clone();

                City city = null;
                int index = -1;

                //Si hay ciudades en la simulación se adicionan como parte de la solución
                if (citiesSimulation != null)
                    c = (ArrayList) citiesSimulation.Clone();
                else
                {
                    //Agrega primera ciudad de forma aleatoria
                    index = random.Next(0, copy.Count);
                    city = (City)copy[index];
                    copy.Remove(city);
                    c.Add(city);
                }
                

                

                //Escoger n ciudades forma aleatoria
                while(c.Count != numberCitiesSimulation)
                {
                    //Obtiene la última ciudad agregada
                    City last = (City) c[c.Count - 1];
                    //Obtiene las adyacencias de la última ciudad
                    Hashtable adjacencies = (Hashtable) last.getAdjacencies().Clone();
        
                    //variable determina si se pudo o no agregar la ciudad
                    Boolean added = false;
                    while(adjacencies.Count != 0 && !added)
                    {
                        //Obtiene la adyacencia con  distancia más grande que existe
                        int max = getBiggerValue(adjacencies);
                        //Retira la distancia más grande de las distancias disponibles
                        adjacencies.Remove(max);

                        City value = findCityBy(max, copy);
                        if(value!=null)
                        {
                            c.Add(value);
                            copy.Remove(value);
                            added = true;
                        }
                        
                    }

                    //Si ninguna ciudad pudo ser agregada se selecciona otra al azar
                    if(!added)
                    {
                        index = random.Next(0, copy.Count);
                        city = (City)copy[index];
                        copy.Remove(city);
                        c.Add(city);
                    }


                }
                calculate_M(c);
                return new Tour(c);
            }

        }
        /// <summary>
        /// Calcula la distancia máxima entre las ciudades de la solución inicial
        /// </summary>
        /// <param name="t">conjunto de ciudades </param>
        private void calculate_M(ArrayList t)
        {
            double sum = 0;
            ArrayList tour = (ArrayList) t.Clone();
            foreach(City c in tour)
            {
                Hashtable n = c.getAdjacencies();
                foreach(DictionaryEntry e in n)
                {
                    if(findCityBy((int)e.Key,tour)!=null)
                    {
                        sum = sum + (double) e.Value;
                    }
                }
            }
            M = sum;
        }
        /// <summary>
        /// Encuentra el identificador de la ciudad vecina con mayor distancia 
        /// </summary>
        /// <param name="list">tabla de adyacencias</param>
        /// <returns>Identificador de la ciudad con mayor distancia</returns>
        private int getBiggerValue(Hashtable list)
        {
            if(list.Count>0)
            {
                double max = -1;
                int city = -1;
                foreach (DictionaryEntry de in list)
                {
                    if ((double)de.Value > max)
                    {
                        max = (double) de.Value;
                        city = (int) de.Key;
                    }
                }
                return city;
            }
            throw new Exception("List must be not empty");
        }
        /// <summary>
        /// Busca un ciudad en una lista de ciudades según su identificador
        /// </summary>
        /// <param name="id">Identificador de la ciudad que se está buscando</param>
        /// <param name="cities">Lista de ciudades en la que se desea buscar</param>
        /// <returns>Ciudad con el identificador solicitado, regresa null en caso de 
        /// no encontrar la ciudad correspondiente</returns>
        public City findCityBy(int id,ArrayList cities)
        {
            foreach(City c in cities)
            {
                if (c.getId() == id)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Busca un ciudad en una lista de ciudades según su posicion
        /// </summary>
        /// <param name="latitude">Latitud de la ciudad a buscar</param>
        /// <param name="longitude">Longitud de la ciudad a buscar</param>
        /// <param name="cities">Conjunto de ciudades en la que se desea buscar</param>
        /// <returns>Ciudad con la posicion solicitado, regresa null en caso de 
        /// no encontrar la ciudad correspondiente</returns>
        public City findCityBy(double latitude, double longitude,ArrayList cities)
        {
            foreach (City c in cities)
            {
                if (c.getLatitude() == latitude && c.getLongitude() == longitude)
                    return c;
            }
            return null;
        }
        /// <summary>
        /// Asigna ciudades incluidas en la simulación
        /// </summary>
        /// <param name="c">ciudades incluidas en la simulación</param>
        public void setCitiesSimulation(ArrayList c)
        {
            citiesSimulation = c;
        }
        /// <summary>
        /// Cuenta la cantidad de ciudades participantes en el problema
        /// </summary>
        /// <returns>cantidad ciudades problema</returns>
        public int countCities()
        {
            return cities.Count;
        }
         

    }
}
