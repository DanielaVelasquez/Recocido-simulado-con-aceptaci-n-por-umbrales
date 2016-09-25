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
        private ArrayList solutions;
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
        private int L;
        /// <summary>
        /// Máximo número de iteraciones de un lote
        /// </summary>
        private int MAX_ITERATIONS;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        
        public Batch(int NBACTH_SIZE, int NMAX_ITERATIONS)
        {
            L = NBACTH_SIZE;
            MAX_ITERATIONS = NMAX_ITERATIONS;
            solutions = new ArrayList();
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

                if(s1.calculateCostFunction() <= (s.calculateCostFunction() + T))
                {
                    s = s1;
                    c = c + 1;
                    r = r + s1.calculateCostFunction();

                    //Guarda todas las soluciones generadas por el lote
                    solutions.Add(s1);
                }
                iterations = iterations + 1;
            }
            finished = c == L;
            //Determina si el lote terminó
            /*if (c==L)
                finished = false;
            else
                finished = true;
            */
            lastSolution = s;
            return r / (double)L;
        }
    }
}
