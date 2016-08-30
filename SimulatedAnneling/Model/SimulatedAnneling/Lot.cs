using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimulatedAnneling.Model.SimulatedAnneling
{
    /// <summary>
    /// Representa un lote producido al generar el recocido simulado
    /// </summary>
    public class Lot
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
        private int temperature;
        /// <summary>
        /// Determina si el lote se generó completo o se detuvo al alcanzar
        /// el máximo número de iteraciones
        /// </summary>
        private Boolean finished;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Constructor de un lote
        /// </summary>
        /// <param name="nTemperature">Temperatura a la cual se está generando el lote</param>
        public Lot(int nTemperature)
        {
            temperature = nTemperature;
            finished = false;
            solutions = new ArrayList();
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
    }
}
