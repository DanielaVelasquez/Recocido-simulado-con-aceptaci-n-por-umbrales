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
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        private String name;

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

        ///<summary>
        ///Crea ciudad información correspondiente
        ///</summary>
        ///<param name="nLatitude">latitud a la cual esta ubicada la ciudad</param>
        ///<param name="nLongitude">longitud a la cual esta ubicada la ciudad</param>
        ///<param name="nName">nombre de la ciudad</param>
        public City(String nName, double nLatitude, double nLongitude)
        {
            name = nName;
            latitude = nLatitude;
            longitude = nLongitude;
        }
    }
}
