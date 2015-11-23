using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SunsetChart
{
    public class SunChartTimeControl : SunChartControl
    {
        protected override void RenderFullYearGraph()
        {
            var startOfYear = new DateTime(DateTime.Now.Date.Year, 1, 1);
            var endOfYear = new DateTime(DateTime.Now.Date.Year, 12, 31);
            endOfYear = endOfYear.AddDays(1);
            RenderSunTimeGraph(startOfYear, endOfYear);
        }

        private void RenderSunTimeGraph(DateTime startOfYear, DateTime endOfYear)
        {
            ClearGraph();
            var sunTimeSerie = AddSerie("Suntime", "Sonnenstunden", Color.Chocolate);
            var currentDateTime = startOfYear;
            while (currentDateTime <= endOfYear)
            {
                DateTime sunriseTime = DateTime.MinValue, sunsetTime = DateTime.MinValue;
                bool isSunset = false, isSunrise = false;
                SunTimes.Instance.CalculateSunRiseSetTimes(Position.Latitude, Position.Longitude, currentDateTime,
                    ref sunriseTime, ref sunsetTime, ref isSunrise, ref isSunset);

                TimeSpan timeSpan = sunsetTime - sunriseTime;
                DateTime date = currentDateTime.Add(timeSpan);
                sunTimeSerie.Points.AddXY(currentDateTime.Date, date);

                currentDateTime = currentDateTime.AddDays(1);
            }
            EnableGridOptions();
        }

        private void EnableGridOptions()
        {
            MainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            MainChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            MainChart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Days;
            MainChart.ChartAreas[0].CursorY.IntervalType = DateTimeIntervalType.Minutes;

            MainChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            MainChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;

            DrawCurrentDay();
            MainChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Minutes;
            //mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            //mainChart.ChartAreas[0].AxisY.

            MainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            MainChart.ChartAreas[0].AxisY.IsMarginVisible = true;

           
            MainChart.ChartAreas[0].AxisY.Minimum = 0.30;
            MainChart.ChartAreas[0].AxisY.Maximum = 0.75;
           

            MainChart.ChartAreas[0].AxisY.ScaleBreakStyle = new AxisScaleBreakStyle
            {
                BreakLineStyle = BreakLineStyle.Ragged,
                Enabled = true,
                LineColor = Color.Gray
            };
        }

        protected override void DrawCurrentHour()
        {
            
        }
    }
}