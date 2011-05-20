using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGeo.Net
{
    class Context
    {
        // TODO: this may only work for lon,lat requests
        private KeyValuePair<String, Double>[] query = new KeyValuePair<String, Double>[2];
        private String timestamp;
        private FeatureCollection Features;

    }
}
