using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimulatedAnneling.Model.TravelerSalesmanProblem
{
    /// <summary>
    /// Ciudad hacia donde se puede dirigir el viajero
    /// </summary>
    public class City
    {
        /**-------------------------------------------------------------------------------------------
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Valor permite representar la no existencia de conexión entre una ciudad y otra
        ///</summary>
        public const double INFINITE = 445970000;//->35//318550000;//->25veces tierr//101936000;//89194000;//22171957741;//22171957741.07997;//double.MaxValue;
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        
        ///<summary>
        ///Número único que representa la ciudad
        ///</summary>
        private int id;
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        private String name;
        /// <summary>
        /// Nombre País al que pertenece la ciudad
        /// </summary>
        private String country;
        /// <summary>
        /// Cantidad de habitantes de la ciudad
        /// </summary>
        private int population;
        /// <summary>
        /// Latitud ciudad
        /// </summary>
        private double latitude;
        /// <summary>
        /// Longitud ciudad
        /// </summary>
        private double longitude;
        /// <summary>
        /// Ciudades vecinas y distancia respectivas a ellos key, identificar ciudad, value: distancia
        /// </summary>
        private Hashtable adjacencies;
        /// <summary>
        /// Tour manager en el cual se encuentra la gestión de la ciudad
        /// </summary>
        private TourManager manager;

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/

        public City(int nId, String nName, String nCountry, int nPopulation, double nLatitude, double nLongitude,TourManager m)
        {
            id = nId;
            name = nName;
            country = nCountry;
            population = nPopulation;
            latitude = nLatitude;
            longitude = nLongitude;
            manager = m;
        }
        public void setAdjacencies(Hashtable a)
        {
            adjacencies = a;
        }
        /// <summary>
        /// Obtiene el identificador de la ciudad
        /// </summary>
        /// <returns>identificador de la ciudad</returns>
        public int getId()
        {
            return id;
        }
        /// <summary>
        /// Obtiene la tabla de adyacencias de la ciudad
        /// </summary>
        /// <returns>tabla de adyacencias de la ciudad</returns>
        public Hashtable getAdjacencies()
        {
            return adjacencies;
        }
        /// <summary>
        /// Retorna la distancia existente entre la ciudad y la ciuda con identificador id
        /// </summary>
        /// <param name="id">identificador ciudad a la que se quiere saber la distancia</param>
        /// <returns>distancia entre la ciudad actual y la ciudad con identificador id</returns>
        public double distanceTo(int id)
        {
            try
            {
                double l = (double)adjacencies[id];
                return  l;
            }
            catch
            {
                return TourManager.get_infinite();
            }
        }   
        /// <summary>
        /// Obtiene una lista de la ciudades adyacentes a la ciudad actual
        /// </summary>
        /// <returns>listado de ciudades adyacentes</returns>
        public ArrayList getAdjacentCities()
        {

            ArrayList cities = new ArrayList();
            foreach(DictionaryEntry de in adjacencies)
            {
                int id = (int)de.Key;
                City c = manager.findCityBy(id, manager.getCities());
                if (c != null)
                {
                    cities.Add(c);
                }
                else
                    throw new Exception("City " + this.ToString() + " has an adjacency not define in its tour manager");

            }
            return cities;
        }
        public double getLatitude()
        {
            return latitude;
        }
        public double getLongitude()
        {
            return longitude;
        }
        public String getName()
        {
            return name;
        }
        public String getCountry()
        {
            return country;
        }
        public int getPopulation()
        {
            return population;
        }
        public override string ToString()
        {
            return getName() + ", " + getCountry();
        }
    }
}
