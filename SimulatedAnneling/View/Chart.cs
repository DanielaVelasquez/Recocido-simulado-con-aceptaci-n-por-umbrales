using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatedAnneling.Model;

namespace SimulatedAnneling.View
{
    public partial class Chart : Form
    {
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        ///<summary>
        ///Nombre de la serie que se quiere mostrar
        ///</summary>
        private String serie_name;
        /// <summary>
        /// Título de la gráfica
        /// </summary>
        private String title;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        public Chart(String serie_name, String title)
        {
            this.serie_name = serie_name;
            this.title = title;
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add(serie_name);
            chart1.Series[serie_name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            lb_title.Text = title;
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Añade un nuevo punto al gráfico
        /// </summary>
        /// <param name="x">valor en x</param>
        /// <param name="y">valor en y</param>
        public void addPoint(SimulatedAnneling.Model.Point p)
        {
            chart1.Series[0].Points.AddXY(p.getX(), p.getY());
        }
    }
}
