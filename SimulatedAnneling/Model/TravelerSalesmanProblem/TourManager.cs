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
                //Escoger n ciudades forma aleatoria
                for(int i=0; i< numberCitiesSimulation; i++)
                {

                }
            }
            else
                return getRandomSolutionUsingCities(random);

        }
        private ISolution getRandomSolutionUsingCities(Random random)
        {

        }
         

    }
}
