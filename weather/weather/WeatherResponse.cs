using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    public class WeatherResponse
    {
        public MainInfo Main { get; set; }
        public ArrayList Weather { get; set; }
        public string Name { get; set; }

    }
}
