using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;

namespace TransitFeeds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MetraData MD;
        private void Form1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMap.Position = new PointLatLng(41.881832, -87.623177);

            MD = new MetraData(); MD.Init(this);
            MD.RouteDetails(); MD.GetRoutes();            MD.GetStops();

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            MD.GetPositions();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if(TimerCheck.Checked)
            UpdateButton.PerformClick();
        }

        List<GMapOverlay> GMOPerm = new List<GMapOverlay>();
        public void OverlayPermant(GMapOverlay Overlay)
        {
            gMap.Zoom = gMap.Zoom + 1;
            gMap.Overlays.Add(Overlay);
            GMOPerm.Add(Overlay);
          //  gMap.ZoomAndCenterMarkers(Overlay.Id);
            gMap.Zoom = gMap.Zoom - 1;
        }
        List<GMapOverlay> GMOTemp = new List<GMapOverlay>();
        public void OverlayTemp(GMapOverlay Overlay)
        {
            if (GMOTemp.Count > 0)
            {
                for (int i = 0; i < GMOTemp.Count; i++)
                {
                    if (GMOTemp[i].Id == Overlay.Id)
                    {
                        gMap.Overlays.Remove(GMOTemp[i]);
                        GMOTemp[i].Dispose();
                        GMOTemp.Remove(GMOTemp[i]);
                    }
                }
            }
            gMap.Overlays.Add(Overlay);
            foreach (GMapMarker mark in Overlay.Markers)
                gMap.UpdateMarkerLocalPosition(mark);
            gMap.Refresh();
            GMOTemp.Add(Overlay);
        }


    }

}