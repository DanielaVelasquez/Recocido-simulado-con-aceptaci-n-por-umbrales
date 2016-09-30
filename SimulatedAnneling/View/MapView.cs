using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using SimulatedAnneling.Controller;
using System.Collections;
using SimulatedAnneling.Model.TravelerSalesmanProblem;
using System.Threading;
using SimulatedAnneling.ObserverPattern;
using SimulatedAnneling.Model.Anneling;
using SimulatedAnneling.Model;

namespace SimulatedAnneling.View
{
    public partial class MapView : Form, ObserverPattern.IObserver
    {
        /**-------------------------------------------------------------------------------------------
         * Constantes
         *--------------------------------------------------------------------------------------------
         **/

        ///<summary>
        ///Modo donde el mapa se muestra con la información de todo el mundo
        ///</summary>
        public const int MODE_WORLD = 1;
        /// <summary>
        /// Modo para que el mapa muestre una solución
        /// </summary>
        public const int MODE_SOLUTION = 2;
        /// <summary>
        /// Titulo para el gráfico de temperatura vs funcion de costos
        /// </summary>
        private const String TEMP_FUNC_TITLE = "Cost function";
        /// <summary>
        /// Nombre de la serie par las gráficas de costo de funcion
        /// </summary>
        private const String TEMP_FUNC_SERIE = "CostFunction";

        /**-------------------------------------------------------------------------------------------
         * Atributos
         *--------------------------------------------------------------------------------------------
         **/

        ///<summary>
        ///Objeto encargado del control del mapa
        ///</summary>
        private GMapControl gmap;
        /// <summary>
        /// Capa para posicionar marcadores
        /// </summary>
        private GMapOverlay overlayOne;
        /// <summary>
        /// Capa posicionar rutas
        /// </summary>
        private GMapOverlay routesOverlay;
        /// <summary>
        /// Controlador aplicación
        /// </summary>
        private TravelerSalesmanProblem controller;
      
        /// <summary>
        /// Marcador actualmente seleccionado
        /// </summary>
        private GMapMarkerGoogleRed marker;
        /// <summary>
        /// Ultimo marcador seleccionado
        /// </summary>
        private GMapMarkerGoogleRed lastMarker;
        /// <summary>
        /// Modo de operación del mapa
        /// </summary>
        private int mode;
        

        public MapView(int nMode)
        {
            mode = nMode;
            InitializeComponent();
            this.CenterToScreen();
            this.Show();
        }
        private void MapView_Load(object sender, EventArgs e)
        {
            configurateMapControl();
            //Obtiene instancia controlador
            controller = TravelerSalesmanProblem.getInstance();
            setMode();

        }

        /// <summary>
        /// Configure the map accoding to the assigned task
        /// </summary>
        private void setMode()
        {
            if (mode == MODE_WORLD)
            {
                //Dibuja ciudades
                drawCities(controller.getCities());
                gboxSolution.Visible = false;
            }
            else if (mode == MODE_SOLUTION)
            {
                btn_simulate.Visible = false;
                Simulation s = controller.getSimulation();
                if (s != null)
                {
                    while(s.isSimulating())
                    {

                    }
                    draw_simulation(s);
                }
                else
                    throw new Exception("Map needs a simulation to show");
            }
            else
                throw new Exception("Map needs a valid mode");
        }
        private void draw_connections(ArrayList cities)
        {
            routesOverlay.Routes.Clear();

            
            for(int i = 1; i<cities.Count;i++)
            {
                List<PointLatLng> ls = new List<PointLatLng>();

                City last = (City)cities[i - 1];
                City actual = (City)cities[i];
                ls.Add(new PointLatLng(last.getLatitude(), last.getLongitude()));
                ls.Add(new PointLatLng(actual.getLatitude(), actual.getLongitude()));


                GMapRoute r = new GMapRoute(ls, "routes_solution");
                r.Stroke.Color = Color.Black;
                r.Stroke.Width = 2;
                routesOverlay.Routes.Add(r);
            }

        }
        private void draw_simulation(Simulation s)
        {
            draw_tour((Tour)s.getBest());
            setTime(s.getTime());
        }
        private void draw_tour(Tour t)
        {
            drawCities(t.getCities());
            draw_connections(t.getCities());
            configure_cities_solution(t.getCities());
            setCostFunction(t.calculateCostFunction());
        }
        private void setTime(String time)
        {
            txtTime.Text = time;
        }
        /// <summary>
        /// Muestra los resultados de la simulación en pantalla
        /// </summary>
        /*public void configure_simulation()
        {
            controller.simulate();
            Thread.Sleep(5000);
            Simulation s = controller.getSimulation();
            while(s.isSimulating())
            {
               
                Tour tour = (Tour) s.getLastSolution();

                drawCities(tour.getCities());
                draw_connections(tour.getCities());
                configure_cities_solution(tour.getCities());
                setCostFunction(tour.calculateCostFunction());
                Console.WriteLine("********************************cargue y voy a esperar");
                //Mientras esté simulando cada 5 segundos actualizará la pantalla
                Thread.Sleep(5000);
                Console.WriteLine("********************************voy a revisar otra vez");
            }
            Console.WriteLine("ACABE");
        }*/
        private void configure_cities_solution(ArrayList c)
        {
            lsBoxCities.Items.Clear();
            lsBoxCities.Items.AddRange(c.ToArray());
        }
        
        private void drawCities(ArrayList cities)
        {
            overlayOne.Markers.Clear();
            foreach(City c in cities)
            {
                marker = new GMapMarkerGoogleRed(new PointLatLng(c.getLatitude(), c.getLongitude()));
                marker.ToolTipText = c.ToString();
                overlayOne.Markers.Add(marker);
                
            }
            
        }
        /// <summary>
        /// Configura el controlador de mapa para que tenga un zoom máximo, mínimo; se define la escala de 
        /// colores entre otros
        /// </summary>
        private void configurateMapControl()
        {
           gmap = new GMapControl();
           
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.GrayScaleMode = false;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(20, 30);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.ShowTileGridLines = false;
            this.gmap.RoutesEnabled = true;
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(500, 500);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 2D;
            this.gmap.BorderStyle = BorderStyle.FixedSingle;
           
            this.Controls.Add(this.gmap);
            
            ArrayList lsMarcas = new ArrayList();
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.MinZoom = 3;
            gmap.MaxZoom = 17;
            gmap.Zoom = 0;
            gmap.CanDragMap = true;
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            overlayOne = new GMapOverlay(gmap, "OverlayOne");
            routesOverlay = new GMapOverlay(gmap, "routes");
            gmap.Overlays.Add(routesOverlay);
            gmap.Overlays.Add(overlayOne);

            gmap.OnMarkerClick += new MarkerClick(this.markerClick);
            
        }
        private void markerClick(object sender, EventArgs e)
        {
            
                //if(((GMapControl)sender).IsMouseOverMarker)
                marker = (GMapMarkerGoogleRed)sender;
                City c = controller.findCityBy(marker.Position.Lat, marker.Position.Lng);
                if (c != null)
                {
                    setName(c.getName());
                    setCountry(c.getCountry());
                    setPopulation(c.getPopulation());
                    setLatitude(c.getLatitude());
                    setLongitude(c.getLongitude());
                    setConnectedCities(c.getAdjacentCities());

                    if(mode == MODE_WORLD)
                        showConnections();

                }
            
           
        }
        /// <summary>
        /// Muestras las conexiones de una ciudad
        /// </summary>
        /// <param name="c"></param>
        private void setConnectedCities(ArrayList c)
        {
            lsbox_connectedCities.Items.Clear();
            lsbox_connectedCities.Items.AddRange(c.ToArray());
        }
        /// <summary>
        /// Muestra longitud la ciudad
        /// </summary>
        /// <param name="name">cantidad habitantes</param>
        private void setLongitude(double value)
        {
            txt_longitude.Text = "" + value;
        }
        /// <summary>
        /// Muestra latitud la ciudad
        /// </summary>
        /// <param name="name">cantidad habitantes</param>
        private void setLatitude(double value)
        {
            txt_latitude.Text = "" + value;
        }
        /// <summary>
        /// Muestra cantidad habitantes la ciudad
        /// </summary>
        /// <param name="name">cantidad habitantes</param>
        private void setPopulation(int value)
        {
            txt_population.Text = ""+value;
        }
        /// <summary>
        /// Muestra nuevo nombre del país al que pertenece la ciudad
        /// </summary>
        /// <param name="name">Nombre país desea mostrar</param>
        private void setCountry(String country)
        {
            txt_country.Text = country;
        }

        /// <summary>
        /// Muestra nuevo nombre de la ciudad
        /// </summary>
        /// <param name="name">Nombre ciudad desea mostrar</param>
        private void setName(String name)
        {
            txtName.Text = name;
        }
        /// <summary>
        /// Muestras las conecciones entre ciudades
        /// </summary>
        private void showConnections()
        {
            //Obtiene la ciudad en la cual se ubicó el usuario
            if(marker!=null && marker != lastMarker)
            {
                lastMarker = marker;
                Console.WriteLine("HAY MARKER");
                City c = controller.findCityBy(marker.Position.Lat, marker.Position.Lng);
                if (c != null)
                {
                    Console.WriteLine(c.ToString());
                    //Crea una lista de posiciones
                    //List<PointLatLng> ls = new List<PointLatLng>();
                    //Obtiene lista ciudades adyacentes
                    ArrayList cities = c.getAdjacentCities();
                    //Obtiene la ubicacion de cada una de las ciudades adyacentes
                    foreach (City city in cities)
                    {
                        List<PointLatLng> ls = new List<PointLatLng>();
                        ls.Add(new PointLatLng(c.getLatitude(), c.getLongitude()));
                        ls.Add(new PointLatLng(city.getLatitude(), city.getLongitude()));
                        //Crea una ruta
                        GMapRoute r = new GMapRoute(ls, "routes");
                        r.Stroke.Color = Color.Black;
                        r.Stroke.Width = 2;
                        routesOverlay.Routes.Add(r);
                    }
                    Thread clean = new Thread(cleanConnections);
                    clean.Start();
                           
                }
                   
            }
            
                
        }
        /// <summary>
        /// Quita las conexiones entre ciudades cuando el usuario mueve el mouse
        /// </summary>
        private void cleanConnections()
        {
            while(gmap.IsMouseOverMarker)
            {

            }
            lastMarker = null;
            routesOverlay.Routes.Clear();
        }
        private void btn_simulate_Click(object sender, EventArgs e)
        {

            //this.Dispose();
            //settings.CenterToScreen();
            SimulationSettings settings = new SimulationSettings();
            settings.Show();
            this.Hide();
            
        }

        private void MapView_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void lsbox_connectedCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            City c = (City)lsbox_connectedCities.SelectedItem;
            if(c!=null)
            {
                gmap.Position = new PointLatLng(c.getLatitude(), c.getLongitude());
            }
        }
        
        public void update(String command)
        {
            Tour tour = (Tour)controller.getSimulation().getSolution();
            drawCities(tour.getCities());
            //setCostFunction (""+ tour.calculateCostFunction());
        }
        private void setCostFunction(double t)
        {
            txtCostFunction.Text = ""+t;
        }

        private void lsBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            City c = (City)lsBoxCities.SelectedItem;
            if (c != null)
            {
                gmap.Position = new PointLatLng(c.getLatitude(), c.getLongitude());
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            Simulation s = controller.getSimulation();
            if(! s.isSimulating())
            {
                Chart chart = new Chart(TEMP_FUNC_SERIE, TEMP_FUNC_TITLE);

                List<double> costs = s.get_costs_function();//s.getAcceptedSolutions();
                int x = 1;
                foreach(double p in costs)
                {
                    SimulatedAnneling.Model.Point point = new Model.Point(x, p);
                    chart.addPoint(point);
                    x++;
                }
                /*
                chart.addPoint(new Model.Point(0.5, 1.358));
                chart.addPoint(new Model.Point(2, 0.23));*/
                chart.Show();
            }
        }
        


    }
}
