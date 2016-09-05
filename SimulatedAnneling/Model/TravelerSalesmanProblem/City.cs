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
        /// Latitud ciudad
        /// </summary>
        private double latitude;

        /// <summary>
        /// Longitud ciudad
        /// </summary>
        private double longitude;

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/

        public City(int nId,String nName,String nCountry, double nLatitude, double nLongitude)
        {
            id = nId;
            name = nName;
            country = nCountry;
            latitude = nLatitude;
            longitude = nLongitude;
        }
    }
}
