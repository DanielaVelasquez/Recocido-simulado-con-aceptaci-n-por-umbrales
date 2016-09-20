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
        private const int MAX_SEEDS = int.MaxValue;
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
            /*controller.addSimulation(3);
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
            this.CenterToScreen();
            //TODO REVISAR EL MAXIMO NUMERO DE CIUDADES QUE SE PUEDEN UTILIZAR PARA SIMULAR PARA OCNFIGRAR EL MAXIMO DEL NUMERADO DE CANTIDAD DE CIUDADES
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
        /// <summary>
        /// Escribe la cantidad total de ciudades disponibles
        /// </summary>
        private void setLabelSizeCities()
        {
            lb_size_cities.Text = "/ " + controller.countCities();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            int seed = (int) numUpSeeds.Value;
        }
    }
}
