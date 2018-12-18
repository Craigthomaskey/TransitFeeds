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

        MetraData MD; DivvyData DD;
        private void Form1_Load(object sender, EventArgs e)
        {
            MainMap.MapProvider = GMap.NET.MapProviders..Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            MainMap.Position = new PointLatLng(41.881832, -87.623177);
            ZoomLabel.Text = ZoomBar.Value.ToString() + "%";
            MainMap.Zoom = ZoomBar.Value; MainMap.ShowCenter = false;


            MD = new MetraData(); MD.Init(this);
            MD.RouteDetails(); MD.GetRoutes();            MD.GetStops();
            MD.GetPositions();

            DD = new DivvyData(); DD.Init(this);
            DD.GetPositions();
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
            MainMap.Zoom = MainMap.Zoom + 1;
            MainMap.Overlays.Add(Overlay);
            GMOPerm.Add(Overlay);
          //  gMap.ZoomAndCenterMarkers(Overlay.Id);
            MainMap.Zoom = MainMap.Zoom - 1;
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
                        MainMap.Overlays.Remove(GMOTemp[i]);
                        GMOTemp[i].Dispose();
                        GMOTemp.Remove(GMOTemp[i]);
                    }
                }
            }            
            MainMap.Overlays.Add(Overlay);
            foreach (GMapMarker mark in Overlay.Markers)
                MainMap.UpdateMarkerLocalPosition(mark);
            MainMap.Refresh();
            GMOTemp.Add(Overlay);
            OverlayVisibleCheck();
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            ZoomLabel.Text = (ZoomBar.Value * 4).ToString() + "%";
            MainMap.Zoom = ZoomBar.Value;
        }

        private void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom > 20) MainMap.Zoom = 20;
            ZoomBar.Value = Convert.ToInt32(MainMap.Zoom);
            ZoomLabel.Text = ZoomBar.Value.ToString() + "%";
        }

        private void MetaCheck_CheckedChanged(object sender, EventArgs e) => OverlayVisibleCheck();
        private void DivvyCheck_CheckedChanged(object sender, EventArgs e) => OverlayVisibleCheck();
        private void CTATrainsCheck_CheckedChanged(object sender, EventArgs e) => OverlayVisibleCheck();
        void OverlayVisibleCheck()
        {
            foreach (GMapOverlay ovly in GMOTemp)
                if (ovly.Id.Contains("Metra"))
                    ovly.IsVisibile = MetaCheck.Checked;
            foreach (GMapOverlay ovly in GMOPerm)
                if (ovly.Id.Contains("Metra"))
                    ovly.IsVisibile = MetaCheck.Checked;
            foreach (GMapOverlay ovly in GMOTemp)
                if (ovly.Id.Contains("Divvy"))
                    ovly.IsVisibile = DivvyCheck.Checked;
            foreach (GMapOverlay ovly in GMOPerm)
                if (ovly.Id.Contains("Divvy"))
                    ovly.IsVisibile = DivvyCheck.Checked;
            foreach (GMapOverlay ovly in GMOTemp)
                if (ovly.Id.Contains("CTATrains"))
                    ovly.IsVisibile = CTATrainsCheck.Checked;
            foreach (GMapOverlay ovly in GMOPerm)
                if (ovly.Id.Contains("CTATrains"))
                    ovly.IsVisibile = CTATrainsCheck.Checked;
        }
    }

}