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

            MySqlDataReader reader = citySQL.execute("SELECT * FROM CITIES");
            while (reader.Read())
            {
                String id = reader[0].ToString();
                Hashtable adjacencies = getAdjacencies(id);
                City c = new City(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), int.Parse(reader[3].ToString()),
                                  double.Parse(reader[4].ToString()), double.Parse(reader[5].ToString()),adjacencies);
                cities.Add(c);
            }
            return cities;
        }
        /// <summary>
        /// Obtiene las adyacencias de una ciudad a partir de su id y guarda en una tabla hash el id de la ciudad
        /// a la qu es vecina junto con su respectiva distancia
        /// </summary>
        /// <param name="id">identificador de la ciudad a la que se quiere encontrar adyacencias</param>
        /// <returns></returns>
        private Hashtable getAdjacencies(String id)
        {
            Hashtable adjacencies = new Hashtable();
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.CommandText = "SELECT * FROM connections WHERE id_city_1 = " + id + " OR id_city_2 = " + id;
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2[0].ToString().Equals(id))
                    adjacencies.Add(int.Parse(reader2[1].ToString()), double.Parse(reader2[2].ToString()));
                else
                    adjacencies.Add(int.Parse(reader2[0].ToString()), double.Parse(reader2[2].ToString()));
            }
            return adjacencies;
        }
    }
}
