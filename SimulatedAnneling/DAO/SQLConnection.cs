using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using SimulatedAnneling.Model.TravelerSalesmanProblem;

namespace SimulatedAnneling.DAO
{
    public class SQLConnection
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        /// <summary>
        /// Contiene información establecer la conexión con la base de datos
        /// </summary>
        private MySqlConnectionStringBuilder builder;
        /// <summary>
        /// Objeto establece conexión con la base de datos
        /// </summary>
        private MySqlConnection connection;

        /**-------------------------------------------------------------------------------------------
         * Metodos
         *--------------------------------------------------------------------------------------------
         **/

        public SQLConnection(String server, String userId, String password, String database)
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = userId;
            builder.Password = password;
            builder.Database = database;
            connection = new MySqlConnection(builder.ToString());
            connection.Open();
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
                City c = new City(int.Parse(reader[0].ToString()),reader[1].ToString(),reader[2].ToString(),int.Parse(reader[3].ToString()),
                                  double.Parse(reader[4].ToString()),double.Parse(reader[5].ToString()));
                cities.Add(c);
            }
            return cities;
        }
    }
}
