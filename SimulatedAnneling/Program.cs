﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatedAnneling.Controller;
using System.IO;
namespace SimulatedAnneling
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            
            if(args.Length>0)
            {

                try
                {
                    TravelerSalesmanProblem controller = TravelerSalesmanProblem.getInstance();
                    int cities;
                    int seed;
                    try
                    {

                        cities = int.Parse(args[0]);
                        seed = int.Parse(args[1]);
                    }
                    catch
                    {
                        throw new Exception("Value cities and seed must be numerical");
                    }


                    if (args.Length == 2)
                    {

                        //Opción 1: Solo entrega semilla y ciudad
                        controller.set_simulation(seed, cities);
                    }
                    else if (args.Length == 3)
                    {
                        String arg3 = args[2];
                        String[] split = arg3.Split(',');
                        if (split.Length > 0)
                        {
                            List<int> id = new List<int>();
                            foreach (String v in split)
                            {
                                try
                                {

                                    id.Add(int.Parse(v));
                                }
                                catch
                                {
                                    throw new Exception("All id values must be numerical");
                                }
                            }
                            controller.set_simulation(seed, cities, id);
                        }
                    }
                    else
                        throw new Exception("Invalid command");

                    controller.simulate();

                    while (controller.getSimulation().isSimulating())
                    {

                    }

                    Console.WriteLine("Best solution: " + controller.getSimulation().getBest().ToString());
                    Console.WriteLine("Time " + controller.getSimulation().getTime());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }
            else
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SimulatedAnneling.View.MapView a = new SimulatedAnneling.View.MapView(SimulatedAnneling.View.MapView.MODE_WORLD);
                Application.Run(a);
                //
            }
        }
    }
}
