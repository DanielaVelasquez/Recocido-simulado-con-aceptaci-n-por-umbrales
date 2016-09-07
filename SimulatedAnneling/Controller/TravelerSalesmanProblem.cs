using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulatedAnneling.Model.TravelerSalesmanProblem;
using System.Collections;
namespace SimulatedAnneling.Controller
{
    public class TravelerSalesmanProblem
    {
        /**-------------------------------------------------------------------------------------------
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Nombre servidor de la base de datos
        ///</summary>
        private const String SERVER = "localhost";
        /// <summary>
        /// Usuario de acceso a la base de datos
        /// </summary>
        private const String USER_ID = "root";
        /// <summary>
        /// Contaseña de acceso a la base de datos
        /// </summary>
        private const String PASSWORD = "root";
        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        private const String DATA_BASE = "tsp";

        /// <summary>
        /// Factor de enfriamiento del sistema, determina que tan rápido o lento
        /// la temperatura disminuyendo
        /// </summary>
        private const double COOLING_FACTOR = 0.65432;

        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private const int BATCH_SIZE = 100;

        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private const int MAX_ITERATION_BATCH = BATCH_SIZE * 300;

        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private const double EP = 0.025;

        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private const double E = 0.015;

        /// <summary>
        /// Valor de la temperatura inicial para el calculo de la temperatura inicial,
        /// segun el problema
        /// </summary>
        private const int INITIAL_TEMPERATURE = 8;

        /// <summary>
        /// Cero virtual para ayudar a detener el algoritmo de
        /// busqueda binaria, al preguntar por la diferencia
        /// de sus temperaturas
        /// </summary>
        private const double ET = 0.036;

        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private const double EACCEPTED = 0.0025;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private const int N = 150;
        /// <summary>
        /// Porcentaje de soluciones aceptadas que se desea tener para calcular
        /// la solución inicial
        /// </summary>
        private const double ACCEPTED_SOLUTIONS = 0.9356;

        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        ///<summary>
        ///Objeto contiene toda la información de las ciudades
        ///</summary>
        private TourManager tourManager;

        /// <summary>
        /// Referencia única del controlador
        /// </summary>
        private static TravelerSalesmanProblem singleton = null;

        /**-------------------------------------------------------------------------------------------
         * Métodos
         *--------------------------------------------------------------------------------------------
         **/
        private TravelerSalesmanProblem()
        {
            tourManager = new TourManager(SERVER, USER_ID, PASSWORD, DATA_BASE);
        }
        /// <summary>
        /// Obtiene la instancia única de la clase
        /// </summary>
        /// <returns>instancia única de la clase</returns>
        public static TravelerSalesmanProblem getInstance()
        {
            if (singleton == null)
                singleton = new TravelerSalesmanProblem();
            return singleton;
        }
        /// <summary>
        /// Entrega ciudades participantes en el problema
        /// </summary>
        /// <returns>ciudades del problema tsp</returns>
        public ArrayList getCities()
        {
            return tourManager.getCities();
        }
    }
}
