using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimulatedAnneling.Controller;
using System.Collections;
using SimulatedAnneling.Model.Anneling;
using System.IO;
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
        private const int MIN_CITIES = 1;
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
        /// <summary>
        /// Ventana dialogo escoger archivo
        /// </summary>
        private OpenFileDialog file_dialog;

        private MapView map_first;
        
        
        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public SimulationSettings(MapView map_first)
        {
            this.map_first = map_first;
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
            try
            {

                int seed = (int)numUpSeeds.Value;
                int cities = (int)numUpNumberCities.Value;

                if (txt_file.Text.Equals(""))
                    controller.set_simulation(seed, cities);
                else
                    controller.set_simulation(seed, cities, txt_file.Text);

                controller.simulate();
                Thread.Sleep(5000);
                btn_run.Enabled = false;

                while (controller.getSimulation().isSimulating())
                {

                }

                this.Hide();


                btn_run.Enabled = true;
                MapView map = new MapView(MapView.MODE_SOLUTION,this);
                map.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numUpNumberCities_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            file_dialog = new OpenFileDialog();
            Stream myStream  =null;
            file_dialog.InitialDirectory = "c:\\desktop";
            file_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            file_dialog.FilterIndex = 2;

            if (file_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = file_dialog.OpenFile()) != null)
                    {
                        String name = file_dialog.FileName;
                        txt_file.Text = name;
                        txt_file.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_file.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            map_first.Show();
            this.Dispose();
        }
    }
}
