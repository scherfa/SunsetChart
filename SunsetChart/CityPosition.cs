using System;

namespace SunsetChart
{
    public class CityPosition
    {
        private static Int32 m_id;
        public CityPosition()
        {
            Id = m_id++;
            TimeZone = "W. Europe Standard Time";
        }
        public int Id { get; private set; }
        public string Caption { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
