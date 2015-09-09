using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SunsetChart
{
    public partial class SunChartControl : UserControl
    {
        private double m_dSelectionStart;
        private double m_dSelectionEnd;
        private bool m_showCurrentDay;
        private bool m_bSummerWinterTime;
   
        private bool m_showSunTime;

        public SunChartControl()
        {
            InitializeComponent();
            CurrentDayColor = Color.CadetBlue;
        }

        public CityPosition Position { get; set; }

        public Color CurrentDayColor { get; set; }

        public bool ShowCurrentDay
        {
            get { return m_showCurrentDay; }
            set { m_showCurrentDay = value; }
        }

        public bool ShowSunTime
        {
            get { return m_showSunTime; }
            set { m_showSunTime = value; }
        }

        public bool SummerWinterTime
        {
            get { return m_bSummerWinterTime; }
            set { m_bSummerWinterTime = value; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            mainChart.MouseMove += chData_MouseMove;

            if (Position != null && Position.Latitude > 0.0 && Position.Longitude > 0.0)
            {
                Render();    
            }
        }

        public void Render()
        {
            SunTimes.Instance.SelectedTimeZone = Position.TimeZone;
            RenderFullYearGraph();
            DrawCurrentDay();
        }

        protected void RenderFullYearGraph()
        {
            var startOfYear = new DateTime(DateTime.Now.Date.Year, 1, 1);
            var endOfYear = new DateTime(DateTime.Now.Date.Year, 12, 31);
            endOfYear=  endOfYear.AddDays(1);

            if (ShowSunTime)
            {
                RenderSunTimeGraph(startOfYear, endOfYear);
            }
            else
            {
                RenderGraph(startOfYear, endOfYear);
            }
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

        private void RenderGraph(DateTime startOfYear, DateTime endOfYear)
        {
            ClearGraph();
            var sunsetSerie = AddSunsetSerie("Sonnenuntergang", Color.Crimson);
            var sunriseSerie = AddSunriseSerie("Sonnenaufgang", Color.MediumBlue);

            var currentDateTime = startOfYear;
            while (currentDateTime <= endOfYear)
            {
                DateTime sunriseTime = DateTime.MinValue, sunsetTime = DateTime.MinValue;
                bool isSunset = false, isSunrise = false;
                SunTimes.Instance.CalculateSunRiseSetTimes(Position.Latitude, Position.Longitude, currentDateTime,
                    ref sunriseTime, ref sunsetTime, ref isSunrise, ref isSunset, SummerWinterTime);

                sunriseSerie.Points.AddXY(currentDateTime.Date, sunriseTime);
                sunsetSerie.Points.AddXY(currentDateTime.Date, sunsetTime);

                currentDateTime = currentDateTime.AddDays(1);
            }
            EnableGridOptions();
        }

        private void ClearGraph()
        {
            mainChart.Series.Clear();
        }

        private void EnableGridOptions()
        {
            mainChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            mainChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = false;
            mainChart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Days;
            mainChart.ChartAreas[0].CursorY.IntervalType =DateTimeIntervalType.Minutes;

            mainChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            mainChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
            
            DrawCurrentDay();
            mainChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Minutes;
            //mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            //mainChart.ChartAreas[0].AxisY.

            mainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            mainChart.ChartAreas[0].AxisY.IsMarginVisible = true;
            if (ShowSunTime)
            {
                mainChart.ChartAreas[0].AxisY.Minimum = 0.30;
                mainChart.ChartAreas[0].AxisY.Maximum = 0.75;
            }
            else
            {
                mainChart.ChartAreas[0].AxisY.Maximum = 0.95;
                mainChart.ChartAreas[0].AxisY.Minimum = 0.15;
            }

            mainChart.ChartAreas[0].AxisY.ScaleBreakStyle = new AxisScaleBreakStyle
            {
                BreakLineStyle = BreakLineStyle.Ragged,
                Enabled = true,
                LineColor = Color.Gray
            };
        }

        private void DrawCurrentDay()
        {
            mainChart.ChartAreas[0].AxisX.StripLines.Clear();
            if (m_showCurrentDay)
            {
                StripLine stripLineToday = new StripLine
                {
                    IntervalOffset = DateTime.Today.ToOADate(),
                    StripWidth = 1,
                    Text = DateTime.Today.ToLongDateString(),
                    TextLineAlignment = StringAlignment.Near,
                    BackColor = CurrentDayColor
                };
                mainChart.ChartAreas[0].AxisX.StripLines.Add(stripLineToday);
            }
        }

        private Series AddSunriseSerie(string caption, Color color)
        {
            return AddSerie("Sunrise", caption, color);
        }

        private Series AddSunsetSerie(string caption, Color color)
        {
            return AddSerie("Sunset", caption, color);
        }

        private Series AddSerie(string name, string caption, Color color)
        {
            Series serie = mainChart.Series.Add(name);
            serie.LegendText = caption;
            serie.Color = color;
            serie.ChartType = SeriesChartType.Line;
            serie.XValueType = ChartValueType.Date;
            serie.YValueType = ChartValueType.Time;
            serie.MarkerStyle = MarkerStyle.None;
            serie.MarkerSize = 0;
            serie.ToolTip = "#VALX [#VALY]";
            return serie;
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = mainChart.HitTest(e.X, e.Y);
             

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // actual values
                mainChart.Annotations.Add(new CalloutAnnotation
                {
                    Name = Guid.NewGuid().ToString(),
                    AnchorDataPoint = result.Series.Points[result.PointIndex],
                    AnchorOffsetX = 5,
                    Text = "X = #VALX\nY = #VALY",
                    ForeColor = Color.Black,
                    AllowSelecting = true,
                    AllowMoving = true     
                });
            }
        }

        private void menuItemSummerTime_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                SummerWinterTime = item.Checked;
                RenderFullYearGraph();
            }
        }

        private void menuItemShowCurrentDay_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                ShowCurrentDay = item.Checked;
            }
            DrawCurrentDay();
        }

   

        private void chart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            m_dSelectionStart = e.NewSelectionStart;
            m_dSelectionEnd = e.NewSelectionEnd;
        }

    
        private void menuItemShowSunTime_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                ShowSunTime = item.Checked;
            }
            RenderFullYearGraph();
        }

        private void chData_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            mainChart.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
            mainChart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            mainChart.ChartAreas[0].CursorY.LineColor = Color.RoyalBlue;
            mainChart.ChartAreas[0].CursorX.LineColor = Color.RoyalBlue;
        }

        
        private void mainChart_DoubleClick(object sender, EventArgs e)
        {
            mainChart.Annotations.Clear();
        }
    }
}
