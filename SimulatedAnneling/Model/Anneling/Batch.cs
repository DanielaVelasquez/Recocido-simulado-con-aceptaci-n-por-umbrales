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

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Constructor de un lote
        /// </summary>
        /// <param name="nTemperature">Temperatura a la cual se está generando el lote</param>
        public Batch(double nTemperature)
        {
            temperature = nTemperature;
            finished = false;
            solutions = new ArrayList();
            best = null;
        }
        /// <summary>
        /// Adiciona una nueva solución al lote
        /// </summary>
        /// <param name="solution">Nueva solución del lote</param>
        public void addSolution(ISolution solution)
        {
            solutions.Add(solution);
        }
        /// <summary>
        /// Cambia el valor de verdad que determina si el lote termino o no
        /// </summary>
        /// <param name="nFinished">Nuevo valor determina si el lote termino o no</param>
        public void setIsFinished(Boolean nFinished)
        {
            finished = nFinished;
        }
        /// <summary>
        /// Cambia la mejor solución del lote
        /// </summary>
        /// <param name="nBest"></param>
        public void setBest(ISolution nBest)
        {
            best = nBest;
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
        public void setLastSolution(ISolution s)
        {
            lastSolution = s;
            if (lastSolution.calculateCostFunction() < best.calculateCostFunction())
                best = lastSolution;
        }
        public ISolution getLastSolution()
        {
            return lastSolution;
        }
    }
}
