using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SimulatedAnneling.Model.SimulatedAnneling;
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
        private int numberCitiesSimulation;
        /// <summary>
        /// Ciudades quiere aparezcan en la simulación
        /// </summary>
        private ArrayList citiesSimulation;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public TourManager(String server, String userId, String password, String database)
        {
            sqlConnection = new SQLConnection(server, userId, password, database);
            cityDAO = new DAOCity(sqlConnection);
            cities = cityDAO.getCities();
            numberCitiesSimulation = CITIES_SIMULATION_NULL;
            citiesSimulation = null;
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
        }

        public ISolution getRamdomSolution(Random random)
        {
            if (numberCitiesSimulation == CITIES_SIMULATION_NULL)
                throw new Exception("You need to set how many cities are going to be use in the simulation");
            else if (citiesSimulation == null || citiesSimulation.Count == 0)
            {
                //Ciudades parte de la solución
                ArrayList c = new ArrayList();
                //Ciudades que no han sido agregadas a la lista de ciudades solución
                ArrayList copy = (ArrayList) cities.Clone();

                //Agrega primera ciudad de forma aleatoria
                int index = random.Next(0,copy.Count);
                City city = (City) copy[index];
                copy.Remove(city);
                c.Add(city);

                //Escoger n ciudades forma aleatoria
                for(int i=1; i < numberCitiesSimulation; i++)
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
                return new Tour(c);
            }
            else
                return getRandomSolutionUsingCities(random);

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
                int max = -1;
                int city = -1;
                foreach (DictionaryEntry de in list)
                {
                    if((int) de.Value>max)
                    {
                        max = (int) de.Value;
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
        private City findCityBy(int id,ArrayList cities)
        {
            foreach(City c in cities)
            {
                if (c.getId() == id)
                    return c;
            }
            return null;
        }
        private ISolution getRandomSolutionUsingCities(Random random)
        {

        }
         

    }
}
