using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatedAnneling.Model.SimulatedAnneling;
using System.Collections;

namespace SimulatedAnneling.Model.TravelerSalesmanProblem
{
    public class Tour: ISolution
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Ciudades deben recorrer para realizar un tour
        ///</summary>
        private ArrayList cities;

        /**-------------------------------------------------------------------------------------------
         * Metodos
         *--------------------------------------------------------------------------------------------
         **/
        public Tour()
        {
            cities = new ArrayList();
        }
        public Tour(ArrayList c)
        {
            cities = c;
        }

        /// <summary>
        /// Adiciona una ciudad al tour
        /// </summary>
        /// <param name="c">ciudad desea adicionar al tour</param>
        public void addCity(City c)
        {
            cities.Add(c);
        }
        /// <summary>
        /// Cuenta cantidad de ciudades tiene el tour
        /// </summary>
        /// <returns>cantidad de ciudades en el tour</returns>
        public int getTourSize()
        {
            return cities.Count;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
