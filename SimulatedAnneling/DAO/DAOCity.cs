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
        public List<City> getCities(TourManager t)
        {
            List<City> cities = new List<City>();

            MySqlDataReader reader = citySQL.execute("SELECT * FROM CITIES");
            while (reader.Read())
            {
                String id = reader[0].ToString();
                //Hashtable adjacencies = getAdjacencies(id);
                City c = new City(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), int.Parse(reader[3].ToString()),
                                  double.Parse(reader[4].ToString()), double.Parse(reader[5].ToString()),t);
                cities.Add(c);
            }
            reader.Close();
            return getAdjacencies(cities);
        }
        /// <summary>
        /// Obtiene las adyacencias de una ciudad a partir de su id y guarda en una tabla hash el id de la ciudad
        /// a la qu es vecina junto con su respectiva distancia
        /// </summary>
        /// <param name="cities">conjunto de ciudades a las cuales se les va a encontrar las adyacnecias</param>
        /// <returns>ciudades con sus adyacencias</returns>
        private List<City> getAdjacencies(List<City> cities)
        {
            foreach(City c in cities)
            {
                String id = ""+c.getId();
                Hashtable adjacencies = new Hashtable();

                MySqlDataReader reader2 = citySQL.execute("SELECT * FROM connections WHERE id_city_1 = " + id + " OR id_city_2 = " + id);
                while (reader2.Read())
                {
                    if (reader2[0].ToString().Equals(id))
                        adjacencies.Add(int.Parse(reader2[1].ToString()), double.Parse(reader2[2].ToString()));
                    else
                        adjacencies.Add(int.Parse(reader2[0].ToString()), double.Parse(reader2[2].ToString()));
                }
                reader2.Close();
                c.setAdjacencies(adjacencies);
            }
           
            return cities;
        }
        
    }
}
