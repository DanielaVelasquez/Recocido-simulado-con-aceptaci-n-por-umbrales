using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimulatedAnneling.ObserverPattern
{
    /// <summary>
    /// Objeto que se está observando y comunica a sus observadores cuando deben actualizarse
    /// </summary>
    public class Observable
    {
        //----------------------------------------------------------------------------------------------
        //Atributos
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Objetos que están observando a este objeto
        /// </summary>
        private ArrayList observers;

        //----------------------------------------------------------------------------------------------
        //Metodos
        //----------------------------------------------------------------------------------------------

        public Observable()
        {
            observers = new ArrayList();
        }
        /// <summary>
        /// Añade un obversador al objeto para que este sea notificado frente a los cambi
        /// de objeto actual
        /// </summary>
        /// <param name="v">nuevo observador</param>
        public void addObserver(IObserver v)
        {
            observers.Add(v);
        }
        /// <summary>
        /// elimina un observador para que deje de ser notificado frente a los cambios
        /// del objeto actual
        /// </summary>
        /// <param name="v"></param>
        public void removeObserver(IObserver v)
        {
            observers.Remove(v);
        }
        /// <summary>
        /// Notifica a todos los observadores que un cambio ocurrió y deben actualizarse
        /// </summary>
        /// <param name="command">comando especifica informacion adicional sobre quien envio
        /// la actualizacion</param>
        public void notify(String command)
        {
            foreach (IObserver v in observers)
                v.update(command);
        }
    }
    
}
