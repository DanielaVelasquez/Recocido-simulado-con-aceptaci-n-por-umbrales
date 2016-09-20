using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatedAnneling
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SimulatedAnneling.View.MapView a = new SimulatedAnneling.View.MapView(SimulatedAnneling.View.MapView.MODE_WORLD);
            Application.Run(a);
            //
        }
    }
}
