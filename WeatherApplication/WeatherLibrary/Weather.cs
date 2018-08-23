using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherLibrary
{
    public class Weather
    {
        public object coord { get; set; }
        public object weather { get; set; }
        public string infoBase { get; set; }
        public object main { get; set; }
        public string visibility { get; set; }
        public object wind { get; set; }
        public object clouds { get; set; }
        public string dt { get; set; }
        public object sys { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string cod { get; set; }
    }
}
