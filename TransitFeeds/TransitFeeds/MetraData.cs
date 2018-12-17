using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransitFeeds
{
    class MetraData
    {
        Form1 MainForm;

        string BaseCall = "https://gtfsapi.metrarail.com";
        string PostionTail = "/gtfs/positions";
        string StopTail = "/gtfs/schedule/stops";
        string RouteTail = "/gtfs/schedule/shapes";
        string RouteDetailsTail = "/gtfs/schedule/routes";
        string Tail = "";


        public void Init(Form1 f)
        {
            MainForm = f;
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

        Dictionary<string, SortedDictionary<float, List<float>>> ShapeData = new Dictionary<string, SortedDictionary<float, List<float>>>();
        Dictionary<string, List<float>> Positions = new Dictionary<string, List<float>>();
        Dictionary<string, string> TrainNames = new Dictionary<string, string>();
        Dictionary<string, List<float>> StopLocations = new Dictionary<string, List<float>>();
        Dictionary<string, string> StopNames = new Dictionary<string, string>();
        Dictionary<string, List<string>> StopZones = new Dictionary<string, List<string>>();


        public void GetPositions()
        {
            string jsonData = GET(BaseCall + PostionTail);

            Positions.Clear();            TrainNames.Clear();

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

            foreach (var v in result)
            {
                string ID = v.vehicle.vehicle.id;
                float Lat = v.vehicle.position.latitude; float Lon = v.vehicle.position.longitude;

                string RouteID = v.vehicle.trip.route_id;
                string VID = v.vehicle.vehicle.label;

                List<float> list = new List<float>() { Lat, Lon };
                Positions.Add(ID, list);
                TrainNames.Add(ID, RouteID + " : " + VID);
            }
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            foreach (var v in Positions)
            {
                PointLatLng PLL = new PointLatLng(v.Value[0], v.Value[1]);
                GMapMarker marker = new GMarkerGoogle(PLL, Properties.Resources.BlueRoundMarker);
                marker.ToolTipText = TrainNames[v.Key];              
                markersOverlay.Markers.Add(marker);
            }
            MainForm.OverlayTemp(markersOverlay);
        }

        Dictionary<string, string> StopUrlDict = new Dictionary<string, string>();
        public void GetStops()
        {
            string jsonData = GET(BaseCall + StopTail);
            StopLocations.Clear(); StopNames.Clear(); StopZones.Clear();
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);
            foreach (var v in result)
            {
                string ID = v.stop_id;
                float Lat = v.stop_lat;
                float Lon = v.stop_lon;
                string name = v.stop_name;
                string zone = v.zone_id;
                string stopURL = v.stop_url;
                List<float> list = new List<float>() { Lat, Lon };
                StopLocations.Add(ID, list); StopNames.Add(ID, name); StopUrlDict.Add(ID, stopURL);
                if (StopZones.ContainsKey(zone)) StopZones[zone].Add(ID);
                else StopZones.Add(zone, new List<string>() { ID });
            }
            GMapOverlay stopsOverlay = new GMapOverlay("stops");

            foreach (var stop in StopLocations)
            {
                PointLatLng PLL = new PointLatLng(stop.Value[0], stop.Value[1]);
              //  GMapMarker marker = new GMarkerGoogle(PLL, Properties.Resources.RedSquareMarker);

                foreach (var v in RouteDetailsDict)
                {
                    if (StopUrlDict[stop.Key].Contains(v.Key))
                    {
                        Bitmap Bmp = new Bitmap(10, 10);
                        for (int h = 0; h < Bmp.Height; h++)
                        {
                            for (int w = 0; w < Bmp.Width; w++)
                            {
                                Bmp.SetPixel(w, h, ColorTranslator.FromHtml("#" + v.Value[1]));
                            }
                        }


                        GMapMarker marker = new GMarkerGoogle(PLL,Bmp);
                        marker.ToolTipText = StopNames[stop.Key];
                        stopsOverlay.Markers.Add(marker);
                    }
                }






            }
            MainForm.OverlayPermant(stopsOverlay);
        }

        public void GetRoutes()
        {
            string jsonData = GET(BaseCall + RouteTail);
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);
            foreach (var v in result)
            {
                string ID = v.shape_id;
                float SequenceNumber = v.shape_pt_sequence;
                float LAT = v.shape_pt_lat; float LON = v.shape_pt_lon;
                if (!ShapeData.ContainsKey(ID))                {                    ShapeData.Add(ID, new SortedDictionary<float, List<float>>() { { SequenceNumber, new List<float>() { LAT, LON } } });                }
                else if (!ShapeData[ID].ContainsKey(SequenceNumber))                {                    ShapeData[ID].Add(SequenceNumber, new List<float>() { LAT, LON });                }
            }            

            GMapOverlay polygons = new GMapOverlay("polygons");
            foreach (var shape in ShapeData)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var point in shape.Value)
                {
                    points.Add(new PointLatLng(point.Value[0], point.Value[1]));
                }
                GMapRoute route = new GMapRoute(points, shape.Key);

                route.Stroke = new Pen(Color.DarkBlue, 5);

                foreach (var v in RouteDetailsDict)
                {
                    if (shape.Key.Contains(v.Key))
                    {
                        route.Stroke = new Pen(ColorTranslator.FromHtml("#" + v.Value[1]), 5);
                    }
                }

                polygons.Routes.Add(route);
            }
            MainForm.OverlayPermant(polygons);

        }

        Dictionary<string, List<string>> RouteDetailsDict = new Dictionary<string, List<string>>();
       public void RouteDetails()
        {
            string jsonData = GET(BaseCall + RouteDetailsTail);
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);
            foreach (var v in result)
            {
                string ID = v.route_id;
                string Color = v.route_color;
                string Name = v.route_long_name;
                RouteDetailsDict.Add(ID, new List<string>() { Name, Color });
            }

        }


    }
}
