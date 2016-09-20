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

namespace SimulatedAnneling.View
{
    public partial class MapView : Form
    {
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

        public MapView()
        {
            InitializeComponent();
        }
        private void MapView_Load(object sender, EventArgs e)
        {
            Console.WriteLine("inicie");
            configurateMapControl();
            //Obtiene instancia controlador
            controller = TravelerSalesmanProblem.getInstance();
            //Dibuja ciudades
            drawCities();
           

            
        }
        private void drawCities()
        {
            ArrayList cities = controller.getCities();
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
            if(c!=null)
            {
                setName(c.getName());
                setCountry(c.getCountry());
                setPopulation(c.getPopulation());
                setLatitude(c.getLatitude());
                setLongitude(c.getLongitude());
                setConnectedCities(c.getAdjacentCities());
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

    }
}
