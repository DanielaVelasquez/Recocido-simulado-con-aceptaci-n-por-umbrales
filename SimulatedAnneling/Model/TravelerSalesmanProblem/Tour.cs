using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatedAnneling.Model.Anneling;
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
        private List<City> cities;
        

        /**-------------------------------------------------------------------------------------------
         * Metodos
         *--------------------------------------------------------------------------------------------
         **/
        public Tour()
        {
            cities = new List<City>();
        }
        public Tour(List<City> c)
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
        public double calculateCostFunction()
        {
            //Recorre todas las ciudades menos la ultima
            double sum = 0;
            for(int i=0; i<cities.Count - 1; i++)
            {
                City c = (City) cities[i];
                City next = (City)  cities[i+1];
                sum = sum + c.distanceTo(next.getId());
            }
            double a = sum / TourManager.get_infinite();
            //double b = sum / (TourManager.M * (TourManager.K - 1));
            return a;
        }
        public ISolution getNeighbour(Random random)
        {
            //TODO mover las dos ciudades con más distancias posibles
            int index1 = random.Next(0, cities.Count);
            int index2 = index1;
            while(index1 == index2)
            {
                index2 = random.Next(0,cities.Count);
            }
            List<City> s = cities.ToList<City>();
            City c1 = (City)s[index1];
            City c2 = (City)s[index2];
            s.Remove(c1);
            s.Remove(c2);
            if (index1 > s.Count)
                s.Add(c2);
            else
                s.Insert(index1, c2);
            if (index2 > s.Count)
                s.Add(c1);
            else
                s.Insert(index2, c1);
            return new Tour(s);

        }
        public override string ToString()
        {
            String s = "Cost function: "+calculateCostFunction()+"\nTotal distance: "+total_distance()+"\n";
            foreach(City c in cities)
            {
                s = s + " [ " + c.ToString() + " ]";
            }
            return s;
        }
        public List<City> getCities()
        {
            return cities;
        }
        public double total_distance()
        {
            double sum = 0;
            for (int i = 0; i < cities.Count - 1; i++)
            {
                City c = (City)cities[i];
                City next = (City)cities[i + 1];
                sum = sum + c.distanceTo(next.getId());
            }
            return sum;
        }
    }
}
