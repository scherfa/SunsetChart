using System.Drawing;

namespace SunsetChart
{
    public class SunsetChartSettings : ApplicationSettings<SunsetChartSettings>
    {
        public string SelectedCity = "Köln";
        public bool ShowCurrentDay = false;
        public bool ShowCurrentHour = false;
        public bool ShowSummerWinterTimeOffset = false;
        public int CurrentDayColor = Color.CadetBlue.ToArgb();
        public int CurrentHourColor = Color.IndianRed.ToArgb();
    }
}