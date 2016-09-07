using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SimulatedAnneling.ObserverPattern;

namespace SimulatedAnneling.Model.SimulatedAnneling
{
    /// <summary>
    /// Modela recocido simulado a partir de un problema
    /// </summary>
    public class SimulatedAnneling : Observable
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
        private ArrayList batchs;
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
        private double EP ;

        /// <summary>
        /// Cero virtual para la temperatura
        /// </summary>
        private double E;

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
        private double ET;

        /// <summary>
        /// Cero virtual para algoritmo de busqueda binaria
        /// con base en el promedio de los aceptados
        /// </summary>
        private double EACCEPTED;
        /// <summary>
        /// Cantidad iteraciones para determinar porcentaje de aceptados a partir
        /// de una temperatura y solución inicial
        /// </summary>
        private int N;
        /// <summary>
        /// Porcentaje de soluciones aceptadas que se desea tener para calcular
        /// la solución inicial
        /// </summary>
        private double ACCEPTED_SOLUTIONS;

        /**-------------------------------------------------------------------------------------------
        * Métodos
        *--------------------------------------------------------------------------------------------
        **/
        /// <summary>
        /// Constructor para el recocido simulado
        /// </summary>
        /// <param name="nSeed">Valor de la semilla para obtener la aletoridad</param>
        public SimulatedAnneling(int nSeed, double COOLING_FACTOR, int BATCH_SIZE, int MAX_ITERATION_BATCH
                                 , double EP, double E, int INITIAL_TEMPERATURE, double ET, double EACCEPTED
                                 , int N, double ACCEPTED_SOLUTIONS)
        {
            this.ACCEPTED_SOLUTIONS = ACCEPTED_SOLUTIONS;
            this.N = N;
            this.INITIAL_TEMPERATURE = INITIAL_TEMPERATURE;
            this.EACCEPTED = EACCEPTED;
            this.ET = ET;
            this.E = E;
            this.EP = EP;
            this.COOLING_FACTOR = COOLING_FACTOR;
            this.BATCH_SIZE = BATCH_SIZE;
            this.MAX_ITERATION_BATCH = MAX_ITERATION_BATCH;
            seed = nSeed;
            temperature = INITIAL_TEMPERATURE;
            random = new Random(seed);
            bestSolution = null;
            batchs = new ArrayList();
        }
        /// <summary>
        /// Realiza la simulación del recocido y retorna la mejor solución encontrada
        /// </summary>
        /// <returns>Mejor solución encontrada</returns>
        public ISolution simulate()
        {
            //Genera una solución inicial
            ISolution initialSolution = manager.getRamdomSolution(random);
            //Calcula la temperatura inicial del problema 
            temperature = initialTemperature(initialSolution, INITIAL_TEMPERATURE, ACCEPTED_SOLUTIONS);
            //Se inicia de nuevo el random
            random = new Random(seed);
            bestSolution = initialSolution;
            simulatedAnneling(initialSolution);
            return bestSolution;

        }
        /// <summary>
        /// Calcula un lote de soluciones dentro del umbral determinado por la temperatura
        /// </summary>
        /// <param name="solution">solución a partir de la cual se va a generar el lote</param>
        /// <returns>Promedio de las soluciones aceptadas</returns>
        private double calculateBatch(ISolution solution)
        {
            //Cantidad de vecinos aceptados
            int neighbours_accepted = 0;
            //Suma costos de función de todos los vecinos aceptados
            double costs_functions = 0;
            //Cantidad de iteraciones
            int iterations = 0;
            //Creación de un lote
            Batch batch = new Batch(temperature);
            //Adiciona primera solucion
            batch.addSolution(solution);
            //Se asume como mejor solución a la solución inicial dada
            batch.setBest(solution);
            while(neighbours_accepted < BATCH_SIZE && iterations < MAX_ITERATION_BATCH)
            {
                ISolution neighbour = solution.getNeighbour(random);
                if (isAccepted(neighbour,solution,temperature))
                {
                    solution = neighbour;
                    neighbours_accepted = neighbours_accepted + 1;
                    costs_functions = costs_functions + neighbour.calculateCostFunction();
                    //Adiciona el vecino aceptado
                    batch.addSolution(neighbour);   
                }
                iterations = iterations + 1;
            }
            //Determina si el lote acabó 
            batch.setIsFinished(neighbours_accepted <= BATCH_SIZE);
            //Adiciona el lote al conjunto de lotes del problema
            batchs.Add(batch);
            //Se guarda la mejor solución del lote
            batch.setBest(solution);
            return costs_functions / BATCH_SIZE;
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
        private void simulatedAnneling(ISolution solution)
        {
            double p = double.MaxValue;
            //Determina si aún se están generando soluciones en un lote
            Boolean isWorking = true;
            while(temperature>E && isWorking)
            {
                double p1 = 0;
                while(Math.Abs(p-p1)>EP)
                {
                    double temp = calculateBatch(solution);
                    //Si el último lote terminó
                    if (didLastBatchEnd())
                    {
                        p1 = p;
                        p = temp;
                        solution = getLastBatch().getBest();
                        //Si es la mejor solucion se guarda
                        if (isAccepted(solution, bestSolution, temperature))
                            bestSolution = solution;
                    }
                    else
                        //Ya no se están produciendo nuevas soluciones, se para el 
                        //algoritmo
                        isWorking = false;

                }
                updateTemperature();
            }
        }
        /// <summary>
        /// Retorna el último lote generado en caso de que exista
        /// </summary>
        /// <returns>último lote generado, en caso de no haber lotes retorna null</returns>
        private Batch getLastBatch()
        {
            //Obtiene indice del ultimo lote en la lista de lotes
            int lastIndex = batchs.Count - 1;
            if (lastIndex>=0)
                return (Batch)batchs[lastIndex];
            return null;
        }
        /// <summary>
        /// Retora si el ultimo lote se generó completo o no
        /// </summary>
        /// <returns>verdadero si el lote se genero completo, falso en caso contrario</returns>
        private Boolean didLastBatchEnd()
        {
            Batch batch = getLastBatch();
            return batch.isFinished();
        }
        /// <summary>
        /// Obtiene una temperatura que aumenta la probabilidad
        /// de desplazarse más rapida y efectivamente por el 
        /// conjunto de soluciones, evitando de igual forma
        /// que sea un enfriamiento demasiado lentp
        /// </summary>
        /// <param name="solution">Solución inicial (aleatoria)</param>
        /// <param name="temp">temperatura inicial arbitraria </param>
        /// <param name="p">
        /// Porcentaje de soluciones que se desea sean aceptadas 
        /// por la temperatura inicial que se quiere encontrar. Aprox
        /// .85<= p <= .95
        /// </param>
        /// <returns></returns>
        private double initialTemperature(ISolution solution,double temp,double p)
        {
            ISolution s = (ISolution) solution.Clone();
            /**
             * Se calcula el porcentaje de soluciones aceptadas
             * a partir de la temperatura arbitraria que se tomo
            */
            double p1 = perAceppted(s, temp);
            double temp1, temp2;
            /**
             * Si la diferencia entre el porcentaje de soluciones
             * aceptadas a partir de los datos iniciales se acerca
             * bastante al porcentaje de soluciones que se quiere
             * acepte la temperatura inicial es decir p1 sea casi p 
             * se dice que la temperatura dada es un temperatura
             * adecuada para iniciar el algoritmo
             **/
            if (Math.Abs(p - p1) <= EP)
                return temp;
            /**
             * Si el porcentaje de soluciones aceptadas (p1) es menor
             * al porcentaje p que se desea tener, se incrementa la 
             * temperatura al doble
             **/ 
            if(p1<p)
            {
                /**
                 * Mientras el porcentaje de soluciones aceptas p1 siga
                 * siendo menor que el porcentaje que se desea se aumenta
                 * la temperatura y se evalua hasta que el porcentaje de 
                 * aceptados se mayor que el que se desea
                 **/
                while(p1<p)
                {
                    temp = 2 * temp;
                    p1 = perAceppted(s, temp);
                }
                /**
                 * --------|------------|-----------
                 *       temp/2        temp
                 **/
                temp1 = temp / 2;
                temp2 = temp;
            }
            else
            {
                /**
                 * Por el contrario si el numero de aceptados excede
                 * el porcentaje de aceptados que se desea, la temperatura 
                 * se disminuye y se evalua hasta que el porcentaje de aceptados
                 * sea el apropiado
                 **/ 
                while(p1>p)
                {
                    temp = temp / 2;
                    p1 = perAceppted(s, temp);
                }
                /**
                 * --------|------------|-----------
                 *       temp         2 * temp
                 **/
                temp1 = temp;
                temp2 = 2 * temp;
            }
            /**
             * Realiza una busqueda binaria entre temp1 y temp2
             * --------|----------|----------|-----------
             *       temp1        ?        temp2 
             * con el objetivo de encontrar un valor intermedio 
             * entre estos que se acerque más al porcentaje de 
             * aceptados que se quiere.
             * temp ha sido cambiado entre 2 incrementandolo y 
             * decrementandolo por eso se hacen las operaciones
             * respectivas para obtener temp1 o temp2
             **/
            return binarySearch(s, temp1, temp2, p);
        }
        /// <summary>
        /// Obtiene el porcentaje de soluciones aceptadas que se generaron
        /// a partir de una solución inicial con una temperatura
        /// </summary>
        /// <param name="s">solución inicial para recorrer el espacio de soluciones</param>
        /// <param name="temperature">temperatura inicial permite conocer el porcentaje de soluciones promedio para dicha  temperatura</param>
        /// <returns>porcentaje de soluciones aceptadas para una temperatura inicial</returns>
        private double perAceppted(ISolution s,double temperature)
        {
            ISolution solution = (ISolution)s.Clone();
            //Cantidad de soluciones aceptadas
            int accepted = 0;
            //Se generan N vecinos a partir de una solución
            for(int i = 0; i<N; i++)
            {
                ISolution neighbour = solution.getNeighbour(random);
                //Si el vecino es aceptado se incrementa la cantidad
                //de soluciones aceptadas
                if (isAccepted(neighbour, solution, temperature))
                    accepted++;
                //Siempre se intercambia la solución por el vecino para
                //para explorar más en el conjunto de soluciones
                solution = neighbour;
            }
            //Retorna cantidad de soluciones aceptadas sobre el numero
            //de soluciones que se generon en total
            return accepted / N;
        }
        /// <summary>
        /// Realiza busqueda binaria para encontrar una temperatura media entre 
        /// las dos temperaturas dadas
        /// </summary>
        /// <param name="s">solucion inicial</param>
        /// <param name="temp1">primera temperatura</param>
        /// <param name="temp2">segunda temperatura</param>
        /// <param name="accepted">porcentaje de soluciones que se van a aceptar</param>
        /// <returns></returns>
        private double binarySearch(ISolution s,double temp1,double temp2,double accepted)
        {
            /**
             * Calcula el valor medio entre las dos temperaturas
             * --------|----------|----------|-------
             *        temp1     average     tem2
             **/
            double average = (temp1 + temp2) / 2;
            
            //Si la diferencia entre las temperaturas es casi 0, se retorna el promedio de ellas
            if (temp2 - temp1 < ET)
                return average;
            /**
             * En otro caso:
             * calcula el porcentaje de soluciones aceptadas con el valor medio entre las
             * temperaturas dadas
             **/ 
            double accepted1 = perAceppted(s, average);
            /**
             * Si la diferencia entre el porcentaje de aceptados con la temperatura media y el porcentaje de aceptados
             * que se desea es muy pequeña, se retorna el promedio entre las temperaturas dadas
             **/
            if (Math.Abs(accepted - accepted1)<EACCEPTED)
                return average;
            /**
             * Si el porcentaje de aceptados con la temperatura media supera el porcentaje de aceptados deseados
             * significa que se debe disminuir la temperatura y se busca entre temp1 y average para encontrar
             * una temperaura promedio entre ellos que cumpla con los requisitos, el caso contrario sinifica
             * que se debe incrementar la temperatura y se realiza una busqueda entre la media y la temperatura 2
             * --------|-----|-----|------|----|-------
             *        temp1  ?   average  ?  tem2
             *         
             **/
            if (accepted1 > accepted)
                return binarySearch(s, temp1, average, accepted);
            else
                return binarySearch(s, average, temp2, accepted);
        }
        /// <summary>
        /// Cambia el valor de la temperatura según el factor de enfriamiento
        /// </summary>
        public void updateTemperature()
        {
            temperature = COOLING_FACTOR * temperature;
            this.notify(null);
        }
        /// <summary>
        /// Regresa la temperatura actual del recocido simulado
        /// </summary>
        /// <returns>Temperatura actual</returns>
        public double getTemperature()
        {
            return temperature;
        }
    }
}
