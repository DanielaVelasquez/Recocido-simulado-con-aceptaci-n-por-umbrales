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
        public const double INFINITE = double.MaxValue;
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

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/

        public City(int nId, String nName, String nCountry, int nPopulation, double nLatitude, double nLongitude, Hashtable a)
        {
            id = nId;
            name = nName;
            country = nCountry;
            population = nPopulation;
            latitude = nLatitude;
            longitude = nLongitude;
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
                return (double) adjacencies[id] ;
            }
            catch
            {
                return INFINITE;
            }
        }   
        public double getLatitude()
        {
            return latitude;
        }
        public double getLongitude()
        {
            return longitude;
        }
    }
}
