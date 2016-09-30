using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SimulatedAnneling.ObserverPattern;

namespace SimulatedAnneling.Model.Anneling
{
    /// <summary>
    /// Modela recocido simulado a partir de un problema
    /// </summary>
    public class Simulation : Observable
    {
        
        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/
        /// <summary>
        /// Temperatura permite explorar soluciones fuera de un mínimo local
        /// </summary>
        private double temperature;
        /// <summary>
        /// Semilla utilizada para aletoriedad de las soluciones
        /// </summary>
        private int seed;
        /// <summary>
        /// Objeto genera números aletorios con base en la semilla
        /// </summary>
        private Random random;
        /// <summary>
        /// Mejor solución encontrada del problema 
        /// </summary>
        private ISolution bestSolution;
        /// <summary>
        /// Lotes generados durante la simulación del recocido
        /// </summary>
        private ArrayList batches;
        /// <summary>
        /// Administrador del problema que se desea resolver
        /// </summary>
        private IManager manager;
        /// <summary>
        /// Factor de enfriamiento del sistema, determina que tan rápido o lento
        /// la temperatura disminuyendo
        /// </summary>
        private double COOLING_FACTOR;

        /// <summary>
        /// Tamaño de los lotes que se van a generar
        /// </summary>
        private int BATCH_SIZE ;

        /// <summary>
        /// Máxima cantidad de iteraciones permitidas cuando se trata
        /// de generar un lote
        /// </summary>
        private int MAX_ITERATION_BATCH ;

        /// <summary>
        /// Cero virtual para el equilibrio témico
        /// </summary>
        private double EP_INITIAL_TEMPERATURE ;

        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private double E_SIMULATED_ANNELING;

        /// <summary>
        /// Valor de la temperatura inicial para el calculo de la temperatura inicial,
        /// segun el problema
        /// </summary>
        private int INITIAL_TEMPERATURE;

        /// <summary>
        /// Cero virtual para ayudar a detener el algoritmo de
        /// busqueda binaria, al preguntar por la diferencia
        /// de sus temperaturas
        /// </summary>
        private double ET_BINARY_SEARCH;

        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private double EP_BINARY_SEARCH;
        /// <summary>
        /// Cero virtual para el algoritmo de recocido simulado
        /// </summary>
        private double EP_SIMULATED_ANNELING;

        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private int N_PERCENTAGE_ACCEPTED;
        /// <summary>
        /// Porcentaje de soluciones aceptadas que se desea tener para calcular
        /// la solución inicial
        /// </summary>
        private double ACCEPTED_SOLUTIONS;
        /// <summary>
        /// Variable determina si se está simulando
        /// </summary>
        private Boolean simulating;
        /// <summary>
        /// Solucion actual del recocido simulado
        /// </summary>
        private ISolution solution;
        /// <summary>
        /// Tiempo tomo a la simulación encontrar una solución
        /// </summary>
        private TimeSpan time;

        private List<Point> accepted_solutions;

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/
        /// <summary>
        /// Constructor para el recocido simulado
        /// </summary>
        /// <param name="nSeed">Valor de la semilla para obtener la aletoridad</param>
        public Simulation(int nSeed, double COOLING_FACTOR, int BATCH_SIZE, int MAX_ITERATION_BATCH
                                 , double EP, double E, int INITIAL_TEMPERATURE, double ET, double EACCEPTED
                                 , int N, double ACCEPTED_SOLUTIONS, double EP_SIMULATED_ANNELING,IManager m)
        {
            this.ACCEPTED_SOLUTIONS = ACCEPTED_SOLUTIONS;
            this.N_PERCENTAGE_ACCEPTED = N;
            this.INITIAL_TEMPERATURE = INITIAL_TEMPERATURE;
            this.EP_BINARY_SEARCH = EACCEPTED;
            this.ET_BINARY_SEARCH = ET;
            this.E_SIMULATED_ANNELING = E;
            this.EP_INITIAL_TEMPERATURE = EP;
            this.COOLING_FACTOR = COOLING_FACTOR;
            this.BATCH_SIZE = BATCH_SIZE;
            this.MAX_ITERATION_BATCH = MAX_ITERATION_BATCH;
            this.EP_SIMULATED_ANNELING = EP_SIMULATED_ANNELING;
            seed = nSeed;
            temperature = INITIAL_TEMPERATURE;
            random = new Random(seed);
            bestSolution = null;
            batches = new ArrayList();
            manager = m;
            simulating = false;

            accepted_solutions = new List<Point>();
        }
        /// <summary>
        /// Realiza la simulación del recocido y retorna la mejor solución encontrada
        /// </summary>
        /// <returns>Mejor solución encontrada</returns>
        public ISolution simulate()
        {
            simulating = true;
            DateTime inicio = DateTime.Now;

            //Genera una solución inicial
            ISolution initial_solution = manager.getRamdomSolution(random);
            Console.WriteLine("Initial solution: " + initial_solution.ToString());
            solution = initial_solution;

            //Calcula la temperatura inicial del problema 
             temperature = initial_temperature(initial_solution, INITIAL_TEMPERATURE, ACCEPTED_SOLUTIONS);
            
            //Se inicia de nuevo el random
            random = new Random(seed);
            //Genera una solución inicial
            initial_solution = manager.getRamdomSolution(random);

            bestSolution = initial_solution;
            solution = initial_solution;
            simulated_anneling();

            DateTime end = DateTime.Now;
            time = end - inicio;

            simulating = false;
            return bestSolution;

        }
        public ISolution getSolution()
        {
            return solution;
        }
        public void setSolution(ISolution s)
        {
            solution = s;
            this.notify(null);
        }
        /// <summary>
        /// Determina si un vecino es aceptado a partir de la temperatura y la solución 
        /// que se tiene de referencia
        /// </summary>
        /// <param name="neighbour">Vecino que se quiere saber si es aceptado</param>
        /// <param name="solution">Solution de la cual se obtuvo el vecino</param>
        /// <param name="temp">Temperatura en la cual se está evaluando la función de costo</param>
        /// <returns> 
        /// verdadero si la funcion de costo del vecino es menor o igual a la función 
        /// de costo de la solución actual más la temperatura, falso en caso contrario
        /// </returns>
        private Boolean isAccepted(ISolution neighbour,ISolution solution, double temp)
        {
            return neighbour.calculateCostFunction() <= solution.calculateCostFunction() + temp;
        }
        /// <summary>
        /// Realiza el recocido simulado a partir de una solución inicial, hasta encontrar
        /// el equilibrio térmico
        /// </summary>
        /// <param name="solution">solución inicial para la simulación</param>
        private void simulated_anneling()
        {
            double p = double.MaxValue;
            accepted_solutions.Add(new Point(bestSolution.calculateCostFunction(), temperature));

            //Determina si aún se están generando soluciones en un lote
            Boolean isWorking = true;
            while(temperature>E_SIMULATED_ANNELING && isWorking)
            {
                double p1 = 0;
                while(Math.Abs(p-p1)>EP_SIMULATED_ANNELING && isWorking)
                {
                    p1 = p;

                    Batch batch = new Batch(BATCH_SIZE, MAX_ITERATION_BATCH);
                    batches.Add(batch);

                    p = batch.calculate_batch(temperature, solution, random);
                    solution = batch.getLastSolution();

                    accepted_solutions.Add(new Point(solution.calculateCostFunction(), temperature));

                    isWorking = batch.isFinished();

                    //Revisa si la mejor solución del batch es mejor que la solucion que se tiene como mejor
                    if (batch.getBest().calculateCostFunction() < bestSolution.calculateCostFunction())
                        bestSolution = batch.getBest();
                    /*
                    double temp = calculateBatch(solution);
                    //Si el último lote terminó
                    if (didLastBatchEnd())
                    {
                        p1 = p;
                        p = temp;
                        setSolution(getLastBatch().getLastSolution());

                        //Ver si la mejor solucion del lote es la mejor solucion que se ha generado
                        if (getLastBatch().getBest().calculateCostFunction() < bestSolution.calculateCostFunction())
                            bestSolution = solution;
                    }
                    else
                        //Ya no se están produciendo nuevas soluciones, se para el 
                        //algoritmo
                        isWorking = false;
                    */

                }
                temperature = COOLING_FACTOR * temperature;
            }
        }
        public List<Point> getAcceptedSolutions()
        {
            return accepted_solutions;
        }
        /// <summary>
        /// Retorna el último lote generado en caso de que exista
        /// </summary>
        /// <returns>último lote generado, en caso de no haber lotes retorna null</returns>
        private Batch getLastBatch()
        {
            //Obtiene indice del ultimo lote en la lista de lotes
            int lastIndex = batches.Count - 1;
            if (lastIndex>=0)
                return (Batch)batches[lastIndex];
            return null;
        }
        /// <summary>
        /// Obtiene una temperatura que aumenta la probabilidad
        /// de desplazarse más rapida y efectivamente por el 
        /// conjunto de soluciones, evitando de igual forma
        /// que sea un enfriamiento demasiado lentp
        /// </summary>
        /// <param name="solution">Solución inicial (aleatoria)</param>
        /// <param name="T">temperatura inicial arbitraria </param>
        /// <param name="P">
        /// Porcentaje de soluciones que se desea sean aceptadas 
        /// por la temperatura inicial que se quiere encontrar. Aprox
        /// .85<= p <= .95
        /// </param>
        /// <returns></returns>
        private double initial_temperature(ISolution solution, double T, double P)
        {
            ISolution s = (ISolution)solution.Clone();
            /**
             * Se calcula el porcentaje de soluciones aceptadas
             * a partir de la temperatura arbitraria que se tomo
            */
            double p = percentage_accepted(s, T);
            double T1, T2;
            /**
             * Si la diferencia entre el porcentaje de soluciones
             * aceptadas a partir de los datos iniciales se acerca
             * bastante al porcentaje de soluciones que se quiere
             * acepte la temperatura inicial es decir p sea casi p 
             * se dice que la temperatura dada es un temperatura
             * adecuada para iniciar el algoritmo
             **/
            if (Math.Abs(P - p) <= EP_INITIAL_TEMPERATURE)
                return T;
            /**
             * Si el porcentaje de soluciones aceptadas (p) es menor
             * al porcentaje P que se desea tener, se incrementa la 
             * temperatura al doble
             **/
            if (p < P)
            {
                /**
                 * Mientras el porcentaje de soluciones aceptas p siga
                 * siendo menor que el porcentaje que se desea se aumenta
                 * la temperatura y se evalua hasta que el porcentaje de 
                 * aceptados se mayor que el que se desea
                 **/
                while (p < P)
                {
                    T = 2 * T;
                    p = percentage_accepted(s, T);
                }
                /**
                 * --------|------------|-----------
                 *       temp/2        temp
                 **/
                T1 = T / 2;
                T2 = T;
            }
            else
            {
                /**
                 * Por el contrario si el numero de aceptados excede
                 * el porcentaje de aceptados que se desea, la temperatura 
                 * se disminuye y se evalua hasta que el porcentaje de aceptados
                 * sea el apropiado
                 **/
                while (p > P)
                {
                    T = T / 2;
                    p = percentage_accepted(s, T);
                }
                /**
                 * --------|------------|-----------
                 *       temp         2 * temp
                 **/
                T1 = T;
                T2 = 2 * T;
            }
            /**
             * Realiza una busqueda binaria entre T1 y T2
             * --------|----------|----------|-----------
             *       T1        ?        T2 
             * con el objetivo de encontrar un valor intermedio 
             * entre estos que se acerque más al porcentaje de 
             * aceptados que se quiere.
             * temp ha sido cambiado entre 2 incrementandolo y 
             * decrementandolo por eso se hacen las operaciones
             * respectivas para obtener T1 o T2
             **/
            return binary_search(s, T1, T2, P);
        }
        /// <summary>
        /// Obtiene el porcentaje de soluciones aceptadas que se generaron
        /// a partir de una solución inicial con una temperatura
        /// </summary>
        /// <param name="solution">solución inicial para recorrer el espacio de soluciones</param>
        /// <param name="T">temperatura inicial permite conocer el porcentaje de soluciones promedio para dicha  temperatura</param>
        /// <returns>porcentaje de soluciones aceptadas para una temperatura inicial</returns>
        private double percentage_accepted(ISolution solution,double T)
        {
            ISolution s = (ISolution)solution.Clone();
            //Cantidad de soluciones aceptadas
            int c = 0;
            //Se generan N vecinos a partir de una solución
            for(int i = 0; i<N_PERCENTAGE_ACCEPTED; i++)
            {
                ISolution s1 = s.getNeighbour(random);
                //Si el vecino es aceptado se incrementa la cantidad
                //de soluciones aceptadas
                if (isAccepted(s1, solution, T))
                    c++;
                //Siempre se intercambia la solución por el vecino para
                //para explorar más en el conjunto de soluciones
                s = s1;
            }
            
            //Retorna cantidad de soluciones aceptadas sobre el numero
            //de soluciones que se generon en total
            return (double) c / (double)  N_PERCENTAGE_ACCEPTED;
        }
        /// <summary>
        /// Realiza busqueda binaria para encontrar una temperatura media entre 
        /// las dos temperaturas dadas
        /// </summary>
        /// <param name="s">solucion inicial</param>
        /// <param name="T1">primera temperatura</param>
        /// <param name="T2">segunda temperatura</param>
        /// <param name="P">porcentaje de soluciones que se van a aceptar</param>
        /// <returns></returns>
        private double binary_search(ISolution s, double T1, double T2, double P)
        {
            /**
             * Calcula el valor medio entre las dos temperaturas
             * --------|----------|----------|-------
             *        T1     average     T2
             **/
            double Tm = (T1 + T2) / 2;

            //Si la diferencia entre las temperaturas es casi 0, se retorna el promedio de ellas
            if (T2 - T1 < ET_BINARY_SEARCH)
                return Tm;
            /**
             * En otro caso:
             * calcula el porcentaje de soluciones aceptadas con el valor medio entre las
             * temperaturas dadas
             **/
            double p = percentage_accepted(s, Tm);
            /**
             * Si la diferencia entre el porcentaje de aceptados con la temperatura media y el porcentaje de aceptados
             * que se desea es muy pequeña, se retorna el promedio entre las temperaturas dadas
             **/
            if (Math.Abs(P - p) < EP_BINARY_SEARCH)
                return Tm;
            /**
             * Si el porcentaje de aceptados con la temperatura media supera el porcentaje de aceptados deseados
             * significa que se debe disminuir la temperatura y se busca entre T1 y Tm para encontrar
             * una temperaura promedio entre ellos que cumpla con los requisitos, el caso contrario sinifica
             * que se debe incrementar la temperatura y se realiza una busqueda entre la media y la temperatura 2
             * --------|-----|-----|------|----|-------
             *        T1  ?   Tm  ?  T2
             *         
             **/
            if (p > P)
                return binary_search(s, T1, Tm, P);
            else
                return binary_search(s, Tm, T2, P);
        }
        /// <summary>
        /// Regresa la temperatura actual del recocido simulado
        /// </summary>
        /// <returns>Temperatura actual</returns>
        public double getTemperature()
        {
            return temperature;
        }

        public override string ToString()
        {
            String r = "Temperature: " + getTemperature() + "\n" +
                   "Best solution: " + bestSolution.ToString() + "\n" +
                   "Seed: " + seed + "\n" +
                   "Batchs: \n";
            foreach(Batch b in batches)
            {
                r = r + "{ " + b.ToString() + " }";
            }

            return r;
        }
        /// <summary>
        /// Obtiene la última solución generada por la simulacion
        /// </summary>
        /// <returns></returns>
        public ISolution getLastSolution()
        {
            return solution;
        }
        public Boolean isSimulating()
        {
            return simulating;
        }

        public String getTime()
        {
            if (time != null)
                return time.Hours + ":" + time.Minutes + ":" + time.Seconds + ":" + time.Milliseconds;
            else
                return "-:-:-:-";
        }

        public ISolution getBest()
        {
            return bestSolution;
        }
        /// <summary>
        /// Retorna un listado de parejas de valores que incluye(temperature, cost_function) 
        /// </summary>
        /// <returns>listado parejas </returns>
        public List<double> get_costs_function()
        {
            List<double> costs = new List<double>();

            foreach(Batch b in batches)
            {
                costs.AddRange(b.get_costs_function());
            }

            return costs;
        }

    }
}
