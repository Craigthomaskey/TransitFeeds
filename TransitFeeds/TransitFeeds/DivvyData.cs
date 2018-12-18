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
    class DivvyData
    {
        Form1 MainForm;
        public void Init(Form1 f)
        {
            MainForm = f;
        }

        string BaseCall = "https://feeds.divvybikes.com/stations/stations.json";

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




        Dictionary<string, Dictionary<string, List<double>>> DataDict = new Dictionary<string, Dictionary<string, List<double>>>();
        public void GetPositions()
        {
            string jsonData = GET(BaseCall);
            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonData);

            foreach (var v in result.stationBeanList)
            {
                string id = v.id;
                string name = v.stationName;
                double Lat = v.latitude; double Lon = v.longitude;
                DataDict.Add(id, new Dictionary<string, List<double>>() { { name, new List<double>() { Lat, Lon } } });
            }

            GMapOverlay markersOverlay = new GMapOverlay("DivvyStations");
            foreach (var v in DataDict)
            {
                foreach (var station in v.Value)
                {
                    PointLatLng PLL = new PointLatLng(station.Value[0], station.Value[1]);
                    Bitmap Bmp = new Bitmap(5, 5);
                    for (int h = 0; h < Bmp.Height; h++)
                    {
                        for (int w = 0; w < Bmp.Width; w++)
                        {
                            Bmp.SetPixel(w, h, Color.LightBlue); 
                        }
                    }
                    GMapMarker marker = new GMarkerGoogle(PLL, Bmp);
                    marker.ToolTipText = station.Key;
                    markersOverlay.Markers.Add(marker);
                }
            }
            MainForm.OverlayTemp(markersOverlay);



        }
    }


    public class StationBeanList
    {
        public int id { get; set; }
        public string stationName { get; set; }
        public int availableDocks { get; set; }
        public int totalDocks { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string statusValue { get; set; }
        public int statusKey { get; set; }
        public string status { get; set; }
        public int availableBikes { get; set; }
        public string stAddress1 { get; set; }
        public string stAddress2 { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string location { get; set; }
        public string altitude { get; set; }
        public bool testStation { get; set; }
        public string lastCommunicationTime { get; set; }
        public string kioskType { get; set; }
        public string landMark { get; set; }
        public bool is_renting { get; set; }
    }

    public class RootObject
    {
        public string executionTime { get; set; }
        public List<StationBeanList> stationBeanList { get; set; }
    }
}
