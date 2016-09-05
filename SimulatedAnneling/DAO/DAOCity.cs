using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;
using SimulatedAnneling.Model.TravelerSalesmanProblem;

namespace SimulatedAnneling.DAO
{
    public class DAOCity
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        ///<summary>
        ///Tiene la conexión a la base de datos
        ///</summary>
        private SQLConnection citySQL;
        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public DAOCity(SQLConnection conn)
        {
            citySQL = conn;
        }

        /// <summary>
        /// Obtiene las ciudades que existen en la base de datos
        /// </summary> 
        /// <returns>lista con las ciudades registradas en la base de datos</returns>
        public ArrayList getCities()
        {
            ArrayList cities = new ArrayList();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM CITIES";

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                City c = new City(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), int.Parse(reader[3].ToString()),
                                  double.Parse(reader[4].ToString()), double.Parse(reader[5].ToString()));
                cities.Add(c);
            }
            return cities;
        }
    }
}
