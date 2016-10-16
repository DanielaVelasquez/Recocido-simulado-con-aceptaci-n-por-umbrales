using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimulatedAnneling.Model.Anneling
{
    /// <summary>
    /// Representa un lote producido al generar el recocido simulado
    /// </summary>
    public class Batch
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Soluciones aceptadas por un lote
        ///</summary>
        private List<ISolution> solutions;
        /// <summary>
        /// Temperatura en la cual fue generado el lote
        /// </summary>
        private double temperature;
        /// <summary>
        /// Determina si el lote se generó completo o se detuvo al alcanzar
        /// el máximo número de iteraciones
        /// </summary>
        private Boolean finished;
        /// <summary>
        /// Mejor solución del lote
        /// </summary>
        private ISolution best;
        /// <summary>
        /// Ultima solución aceptada por el lote
        /// </summary>
        private ISolution lastSolution;
        /// <summary>
        /// Tamaño de un lote
        /// </summary>
        private double L;
        /// <summary>
        /// Máximo número de iteraciones de un lote
        /// </summary>
        private double MAX_ITERATIONS;
        /// <summary>
        /// Lista contiene los costos de función de todas las soluciones aceptadas
        /// </summary>
        private List<double> costs_functions;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/

        public Batch(double NBACTH_SIZE, double NMAX_ITERATIONS)
        {
            L = NBACTH_SIZE;
            MAX_ITERATIONS = NMAX_ITERATIONS;
            solutions = new List<ISolution>();
            costs_functions = new List<double>();
        }
        
        /// <summary>
        /// Determina si el lote terminó
        /// </summary>
        /// <returns>verdadero si el lote termino, falso en caso contrario</returns>
        public Boolean isFinished()
        {
            return finished;
        }
        /// <summary>
        /// Obtiene la mejor solución del lote
        /// </summary>
        /// <returns>Mejor solución del lote</returns>
        public ISolution getBest()
        {
            return best;
        }
        public override string ToString()
        {
            String r = "";
            foreach(ISolution s in solutions)
            {
                r = r + " [ " + s.ToString() + " ] ";
            }
            r = r + "\nBEST: " + best.ToString();
            return r;
        }
        public ISolution getLastSolution()
        {
            return lastSolution;
        }
        /// <summary>
        /// Calcula un lote a partir de una solucion inicial y una temperatura dada
        /// </summary>
        /// <param name="T">Temperatura en la que se encuentra la simulación</param>
        /// <param name="solution">solucion inicial</param>
        /// <param name="random">objeto permite aleatoriedad</param>
        /// <returns></returns>
        public double calculate_batch(double T,ISolution solution,Random random)
        {
            this.temperature = T;

            ISolution s = (ISolution)solution.Clone();

            best = s;
            //Cantidad de soluciones aceptadas
            int c = 0;
            double r = 0;

            int iterations = 0;

            finished = false;

            while(c<L && iterations<MAX_ITERATIONS)
            {
                ISolution s1 = s.getNeighbour(random);
                
                if (s1.calculateCostFunction() < best.calculateCostFunction())
                    best = s1;

                double s1_cost_function = s1.calculateCostFunction();
                double s_cost_function = s.calculateCostFunction();
                if (s1_cost_function <= (s_cost_function + T))
                {
                    s = s1;
                    c = c + 1;
                    r = r + s1_cost_function;

                    //Guarda todas las soluciones generadas por el lote
                    solutions.Add(s1);
                    //Console.WriteLine(s1_cost_function);
                    costs_functions.Add(s1_cost_function);
                }
                iterations = iterations + 1;
            }

           
            finished = c == L;
            lastSolution = s;
            return r / (double)L;
        }
        /// <summary>
        /// Retorna lista de  funcion de costo de cada
        /// solución encontrada
        /// </summary>
        /// <returns>lista funciones de costo de cada solucion encontrada</returns>
        public List<double> get_costs_function()
        {

            return costs_functions;
        }
    }
}
