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

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public TourManager(String server, String userId, String password, String database)
        {
            sqlConnection = new SQLConnection(server, userId, password, database);
            cityDAO = new DAOCity(sqlConnection);
            cities = cityDAO.getCities();
        }

    }
}
