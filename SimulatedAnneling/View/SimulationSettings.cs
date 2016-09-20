using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatedAnneling.Controller;
using System.Collections;
using SimulatedAnneling.Model.Anneling;
namespace SimulatedAnneling.View
{
    public partial class SimulationSettings : Form
    {
        /**-------------------------------------------------------------------------------------------
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Cantidad mínima de ciudades para la simulación
        ///</summary>
        private const int MIN_CITIES = 10;
        /// <summary>
        /// Cantidad mínima de semillas para la simulación
        /// </summary>
        private const int MIN_SEEDS = 1;
        /// <summary>
        /// Cantidad máxima de semillas para la simulación
        /// </summary>
        private const int MAX_SEEDS = 300;
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        private TravelerSalesmanProblem controller;
        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public SimulationSettings()
        {
            InitializeComponent();
            controller = TravelerSalesmanProblem.getInstance();
            controller.addSimulation(3);
            controller.simulacion(10);
            //controller.simulate(20);
            /*ArrayList s = controller.getSimulations();
            foreach (SimulatedAnneling.Model.Anneling.SimulatedAnneling o in s)
            {
                Console.WriteLine("Acabe");
            }*/
        }

        private void SimulationSettings_Load(object sender, EventArgs e)
        {
            
            //TODO REVISAR EL MAXIMO NUMERO DE CIUDADES QUE SE PUEDEN UTILIZAR PARA SIMULAR PARA OCNFIGRAR EL MAXIMO DEL NUMERADO DE CANTIDAD DE CIUDADES
            enableManualEntry(false);
            enableChooseCities(false);
            setLabelSizeCities();
            setNumericUpDown();
        }
        /// <summary>
        /// Configura los controles Numeric up down, con sus valies máximos y mínimos
        /// </summary>
        private void setNumericUpDown()
        {
            numUpNumberCities.Maximum = controller.countCities();
            numUpNumberCities.Minimum = MIN_CITIES;

            numUpSeeds.Maximum = MAX_SEEDS;
            numUpSeeds.Minimum = MIN_SEEDS;
        }
        private void lb_seed_values_Click(object sender, EventArgs e)
        {
            //TODO hacer botones para que a partir de una misma solucion inicial, con una semilla para dicha solucion inicial, las demás semillan corran a partir de dicha solución inicial y ver cual de todas dá la mejor solución
            
        }
        /// <summary>
        /// Habilita o deshabilita los controles relacionados a la entrada manual de las semillas
        /// </summary>
        /// <param name="val">valor de verdad para habilitar = true o no habilitar = false los controles</param>
        private void enableManualEntry(Boolean val)
        {
            txt_seed_manual_input.Enabled = val;
            btn_add_seed.Enabled = val;
            btn_remove_seed.Enabled = val;
        }
        /// <summary>
        /// Habilita o deshabilita los controles relacionados a escoger ciudades para la simulación
        /// </summary>
        /// <param name="val">valor de verdad para habilitar = true o no habilitar = false los controles</param>
        private void enableChooseCities(Boolean val)
        {
            txt_search.Enabled = val;
            btn_find.Enabled = val;
            cb_cities.Enabled = val;
            //TODO las ciudades disponibles deben ir desapareciendo conforme se agregan a la simulación
            ls_cities.Enabled = val;
            btn_add_city.Enabled = val;
            ls_selected_cities.Enabled = val;
            btn_remove_city.Enabled = val;
        }
        /// <summary>
        /// Habilita o deshabilita los controles relacionados a la semilla inicial
        /// </summary>
        /// <param name="val">valor de verdad para habilitar = true o no habilitar = false los controles</param>
        private void enableInitialSeed(Boolean val)
        {
            txt_initial_seed.Enabled = val;
        }
        private void ckBoxManualInput_CheckedChanged(object sender, EventArgs e)
        {
            /*if (ckBoxManualInput)
                enableManualEntry(true);
             * */
        }
        /// <summary>
        /// Escribe la cantidad total de ciudades disponibles
        /// </summary>
        private void setLabelSizeCities()
        {
            lb_size_cities.Text = "/ " + controller.countCities();
        }
    }
}
