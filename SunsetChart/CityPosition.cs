using System;

namespace SunsetChart
{
    public class CityPosition
    {
        private static int m_id;
        public CityPosition()
        {
            Id = m_id++;
        }

        public int Id { get; }
        public string Caption { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; } = "W. Europe Standard Time";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
