using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatedAnneling.View
{
    public partial class SimulationSettings : Form
    {
        public SimulationSettings()
        {
            InitializeComponent();
        }

        private void SimulationSettings_Load(object sender, EventArgs e)
        {
            //TODO REVISAR EL MAXIMO NUMERO DE CIUDADES QUE SE PUEDEN UTILIZAR PARA SIMULAR PARA OCNFIGRAR EL MAXIMO DEL NUMERADO DE CANTIDAD DE CIUDADES
        }

        private void lb_seed_values_Click(object sender, EventArgs e)
        {

        }
    }
}
