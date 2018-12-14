using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransitFeeds
{
    class MetraData
    {
        string BaseCall = "https://gtfsapi.metrarail.com";
        string PostionTail = "/gtfs/raw/positionUpdates.dat";
        string StopTail = "/gtfs/schedule/stops";
        string RouteTail = "/gtfs/schedule/shapes";
        string Tail = "";



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





    }
}
