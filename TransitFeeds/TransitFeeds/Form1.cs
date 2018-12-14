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

        private void Form1_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMap.Position = new PointLatLng(41.881832, -87.623177);
            GetPositions(GET("https://gtfsapi.metrarail.com/gtfs/positions"));
            GetRoutes(GET("https://gtfsapi.metrarail.com/gtfs/schedule/stops"));
            PositionsButton.Enabled = true;
            foreach (var v in Positions)
            {
                MainFeed.Text = MainFeed.Text + v.Key + " : " + v.Value[0] + " , " + v.Value[0] + Environment.NewLine;
            }
            PositionsButton.PerformClick();
        }

        string GET(string url)
        {
            string username = "fc9a6873a68bc45e909e3d3bacaa1dd3";
            string password = "a6bf1d34173884b3b9e46d413d54650d";

            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Credentials = new NetworkCredential(username, password);
            var response = req.GetResponse();

            Stream Strm = response.GetResponseStream();
            StreamReader StrmRdr = new StreamReader(Strm);
            return StrmRdr.ReadToEnd();
        }


        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MainFeed.Text);
        }

        Dictionary<string, List<float>> Positions = new Dictionary<string, List<float>>();
        void GetPositions(string jsonData)
        {
            Positions.Clear();

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

            foreach(var v in result)
            {
                string ID = v.vehicle.vehicle.id;
                float Lat = v.vehicle.position.latitude; float Lon = v.vehicle.position.longitude;
                List<float> list = new List<float>() { Lat, Lon };
                Positions.Add(ID, list);

            }
        }

        Dictionary<string, List<float>> StopLocations = new Dictionary<string, List<float>>();
        Dictionary<string, string> StopNames = new Dictionary<string, string>();
        Dictionary<string, List<string>> StopZones = new Dictionary<string, List<string>>();

        void GetRoutes(string jsonData)
        {
            StopLocations.Clear(); StopNames.Clear(); StopZones.Clear();

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

            foreach (var v in result)
            {
                string ID = v.stop_id;
                float Lat = v.stop_lat;
                float Lon = v.stop_lon;
                string name = v.stop_name;
                string zone = v.zone_id;
                List<float> list = new List<float>() { Lat, Lon };
                StopLocations.Add(ID, list); StopNames.Add(ID, name);

                if (StopZones.ContainsKey(zone)) StopZones[zone].Add(ID);
                else StopZones.Add(zone, new List<string>() { ID });
            }
        }

        private void PositionsButton_Click(object sender, EventArgs e)
        {
            MainFeed.Text = "";
            GetPositions(GET("https://gtfsapi.metrarail.com/gtfs/positions"));
            GetRoutes(GET("https://gtfsapi.metrarail.com/gtfs/schedule/stops"));
            foreach (var v in Positions)
            {
                MainFeed.Text = MainFeed.Text + v.Key + " : " + v.Value[0] + " , " + v.Value[0] + Environment.NewLine;
            }
            UpdateMap();
        }

        GMapOverlay stopsOverlay;
        GMapOverlay markersOverlay;
        void UpdateMap()
        {
            gMap.Overlays.Clear();

            if (stopsOverlay != null) stopsOverlay.Clear(); else stopsOverlay = new GMapOverlay("stops");

            foreach (var v in StopLocations)
            {
                PointLatLng PLL = new PointLatLng(v.Value[0], v.Value[1]);
                GMapMarker marker = new GMarkerGoogle(PLL, GMarkerGoogleType.black_small);
                marker.ToolTipText = v.Key;
                stopsOverlay.Markers.Add(marker);
            }
            gMap.Overlays.Add(stopsOverlay);

            if (markersOverlay != null) markersOverlay.Clear(); else markersOverlay = new GMapOverlay("markers");
            foreach (var v in Positions)
            {
                PointLatLng PLL = new PointLatLng(v.Value[0], v.Value[1]);
                GMapMarker marker = new GMarkerGoogle(PLL, GMarkerGoogleType.blue_pushpin);
                marker.ToolTipText = v.Key;
                markersOverlay.Markers.Add(marker);
            }
            gMap.Overlays.Add(markersOverlay);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            PositionsButton.PerformClick();            
        }

        private void ShapesBttn_Click(object sender, EventArgs e)
        {
            OverlayShapes(GET("https://gtfsapi.metrarail.com/gtfs/schedule/shapes"));
            ShapesBttn.Enabled = false;
        }

        Dictionary<string, SortedDictionary<float, List<float>>> ShapeData = new Dictionary<string, SortedDictionary<float, List<float>>>();

        void OverlayShapes(string jsonData)
        {
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

            foreach (var v in result)
            {
                string ID = v.shape_id;
                float SequenceNumber = v.shape_pt_sequence;
                float LAT = v.shape_pt_lat; float LON = v.shape_pt_lon;

                if (!ShapeData.ContainsKey(ID))
                {
                    ShapeData.Add(ID, new SortedDictionary<float, List<float>>() { { SequenceNumber, new List<float>() { LAT, LON } } });
                }
                else if(!ShapeData[ID].ContainsKey(SequenceNumber))
                {
                    ShapeData[ID].Add(SequenceNumber, new List<float>() { LAT, LON });
                }
            }



            GMapOverlay polygons = new GMapOverlay("polygons");
            foreach (var shape in ShapeData)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach(var point in shape.Value)
                {
                    points.Add(new PointLatLng(point.Value[0], point.Value[1]));
                }
                GMapRoute route = new GMapRoute(points, shape.Key);
                route.Stroke = new Pen(Color.Red, 3);
                polygons.Routes.Add(route);           
            }
            gMap.Overlays.Add(polygons);

        }

    }

}