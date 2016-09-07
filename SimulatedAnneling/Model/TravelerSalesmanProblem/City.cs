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
    }
}
