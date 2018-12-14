using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitFeeds
{
    class DivvyData
    {

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
