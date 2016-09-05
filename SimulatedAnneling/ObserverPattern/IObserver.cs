using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatedAnneling.ObserverPattern
{
    /// <summary>
    /// Define un objeto que se actualiza cuando es invocado
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Actualiza el objeto
        /// </summary>
        /// <param name="comando"></param>
        void update(String command);
    }
}
