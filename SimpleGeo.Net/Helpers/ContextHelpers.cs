using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGeo.Net.Helpers
{
    class Query
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Query() { }

        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    class Feature
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Feature() { }

        public string handle { get; set; }
        public string name { get; set; }
        public string license { get; set; }
        public double[] bounds { get; set; }
        public string href { get; set; }
        public string abbr { get; set; }
        public Classifier[] classifiers { get; set; }
    }

    class Classifier
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Classifier() { }

        public string category { get; set; }
        public string type { get; set; }
        public string subcategory { get; set; }
    }

    class Weather
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Weather() { }

        public string wind_speed { get; set; }
        public string temperature { get; set; }
        public string dewpoint { get; set; }
        public string cloud_cover { get; set; }
        public string wind_direction { get; set; }
        public Forcast forcast { get; set; }
        public string conditions { get; set; }
    }

    class Forcast
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Forcast() { }

        public DailyForcast today { get; set; }
        public DailyForcast tonight { get; set; }
        public DailyForcast tomorrow { get; set; }
    }

    class DailyForcast
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public DailyForcast() { }

        public string conditions { get; set; }
        public string precipitation { get; set; }
        public Temperature temperature { get; set; }
    }

    class Temperature
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Temperature() {}

        public string max { get; set; }
        public string min { get; set; }
    }

    class Intersection
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Intersection() { }

        public double distance { get; set; }
        public Geometry geometry { get; set; }
        public IntersectionProperties properties { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }

    class IntersectionProperties
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public IntersectionProperties() { }

        public Highway[] highways { get; set; }
        public string attribution { get; set; }
        public string license { get; set; }
    }

    class Highway
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Highway() { }

        public string osm_way_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

    class Demographics
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Demographics() { }

        public int population_density { get; set; }
    }

    class Address
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Address() { }

        public Geometry geometry { get; set; }
        public AddressProperties properties { get; set; }
        public string type { get; set; }
    }

    class Geometry
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public Geometry() { }

        public double[] coordinates { get; set; }
        public string type { get; set; }

    }

    class AddressProperties
    {
        /// <summary>
        /// No-Arg constructor is necessary for the de-serialization of JSON data
        /// </summary>
        public AddressProperties() { }

        public string address { get; set; }
        public string distance { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string province { get; set; }
        public string country { get; set; }
    }
}
