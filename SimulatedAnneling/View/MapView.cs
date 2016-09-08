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
        /// Capa permite posicionar marcadores
        /// </summary>
        private GMapOverlay overlayOne;
        /// <summary>
        /// Controlador aplicación
        /// </summary>
        private TravelerSalesmanProblem controller;

        public MapView()
        {
            InitializeComponent();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            configurateMapControl();
            //Obtiene instancia controlador
            controller = TravelerSalesmanProblem.getInstance();
            drawCities();
        }
        private void drawCities()
        {
            ArrayList cities = controller.getCities();
            foreach(City c in cities)
            {
                GMapMarkerGoogleRed marker = new GMapMarkerGoogleRed(new PointLatLng(c.getLatitude(), c.getLongitude()));
                marker.ToolTipText = c.ToString();
                overlayOne.Markers.Add(marker);
                
            }
            gmap.Overlays.Add(overlayOne);
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

            //gmap.Click += new System.EventHandler(this.markerClick);
            //Evento para saber cuando una marca fue seleccionada
            gmap.OnMarkerClick += new MarkerClick(this.markerClick);
            
        }
        private void markerClick(object sender, EventArgs e)
        {
            //if(((GMapControl)sender).IsMouseOverMarker)
            GMapMarkerGoogleRed marker = (GMapMarkerGoogleRed)sender;
            City c = controller.findCityBy(marker.Position.Lat, marker.Position.Lng);
            if(c!=null)
            {
                setName(c.getName());
                setCountry(c.getCountry());
                setPopulation(c.getPopulation());
                setLatitude(c.getLatitude());
                setLongitude(c.getLongitude());
            }
        }
        /// <summary>
        /// Muestras las conexiones de una ciudad
        /// </summary>
        /// <param name="c"></param>
        private void setConnectedCities(ArrayList c)
        {
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
        private void btn_simulate_Click(object sender, EventArgs e)
        {

        }

    }
}
