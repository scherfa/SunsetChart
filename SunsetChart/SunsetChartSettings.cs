namespace SunsetChart
{
    public class SunsetChartSettings : ApplicationSettings<SunsetChartSettings>
    {
        public string SelectedCity = "Köln";
        public bool ShowCurrentDay = false;
        public bool ShowCurrentHour = false;
        public bool ShowSummerWinterTimeOffset = false;
    }
}