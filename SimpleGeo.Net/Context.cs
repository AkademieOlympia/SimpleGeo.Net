using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGeo.Net
{
    using SimpleGeo.Net.Helpers;

    class Context
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Context() { }


        public Query query { get; set; }
        public string timestamp { get; set; }
        public Feature[] features { get; set; }
        public Weather weather { get; set; }
        public Intersection[] intersections { get; set; }
        public Demographics demographics { get; set; }
        public Address address { get; set; }
    }
}
