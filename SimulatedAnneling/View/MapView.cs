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
        private GMapControl mapControl;



        public MapView()
        {
            InitializeComponent();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            configurateMapControl();
        }
        /// <summary>
        /// Configura el controlador de mapa para que tenga un zoom máximo, mínimo; se define la escala de 
        /// colores entre otros
        /// </summary>
        private void configurateMapControl()
        {
            mapControl = new GMapControl();
            ///Zoom máximo y mínimo
            mapControl.MaxZoom = 18;
            mapControl.MinZoom = 2;
            ///No se maneja en escala de grises 
            mapControl.GrayScaleMode = false;
            //permite al usuario moverse en el mapa usando el raton
            mapControl.CanDragMap = true;

            ///Se configura para que reciba información de google maps
            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.Manager.Mode = AccessMode.ServerAndCache;
            mapControl.Zoom = 2D;

            mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
        }
    }
}
