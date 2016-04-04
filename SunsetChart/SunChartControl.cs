using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Windows.Forms.Timer;


namespace SunsetChart
{
    public partial class SunChartControl : UserControl
    {
        private bool m_showCurrentDay;
        private bool m_showCurrentHour;
        private bool m_bSummerWinterTime;

        private Timer m_timer;
        public SunChartControl()
        {
            InitializeComponent();
       
        }

        public CityPosition Position { get; set; }

        public Color CurrentDayColor { get; set; }
        public Color CurrentHourColor { get; set; }


        public bool ShowCurrentDay
        {
            get { return m_showCurrentDay; }
            set { m_showCurrentDay = value; }
        }

        public bool SummerWinterTime
        {
            get { return m_bSummerWinterTime; }
            set { m_bSummerWinterTime = value; }
        }

        public bool ShowCurrentHour
        {
            get { return m_showCurrentHour; }
            set { m_showCurrentHour = value; }
        }

        protected Chart MainChart
        {
            get { return mainChart; }
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
            CurrentDayColor = Color.FromArgb(SunsetChartSettings.Instance.CurrentDayColor);
            CurrentHourColor = Color.FromArgb(SunsetChartSettings.Instance.CurrentHourColor);
            SunTimes.Instance.SelectedTimeZone = Position.TimeZone;
            RenderFullYearGraph();
            DrawCurrent();
        }

        protected virtual void RenderFullYearGraph()
        {
            var startOfYear = new DateTime(DateTime.Now.Date.Year, 1, 1);
            var endOfYear = new DateTime(DateTime.Now.Date.Year, 12, 31);
            endOfYear = endOfYear.AddDays(1);

            RenderGraph(startOfYear, endOfYear);
        }

        private void RenderGraph(DateTime startOfYear, DateTime endOfYear)
        {
            ClearGraph();
            AddTitle();
           
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

        private void AddTitle()
        {
            mainChart.Titles.Clear();

            DateTime sunriseTime = DateTime.MinValue, sunsetTime = DateTime.MinValue;
            bool isSunset = false, isSunrise = false;
            SunTimes.Instance.CalculateSunRiseSetTimes(Position.Latitude, Position.Longitude, DateTime.Today, 
               ref sunriseTime, ref sunsetTime, ref isSunrise, ref isSunset, SummerWinterTime);

            Title area1Title = new Title(String.Format("Heute:\nAufgang:    {0:HH:mm:ss}\nUntergang: {1:HH:mm:ss}",sunriseTime,sunsetTime), Docking.Bottom, new Font("Verdana", 10), Color.Black);
            area1Title.IsDockedInsideChartArea = true;
            area1Title.DockedToChartArea = mainChart.ChartAreas[0].Name;
            area1Title.TextOrientation = TextOrientation.Horizontal;
            area1Title.Alignment = ContentAlignment.MiddleLeft;
            mainChart.Titles.Add(area1Title);
        }

        protected void ClearGraph()
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

            DrawCurrent();
            mainChart.ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Minutes;

            mainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            mainChart.ChartAreas[0].AxisY.IsMarginVisible = true;
            
            mainChart.ChartAreas[0].AxisY.Maximum = 0.95;
            mainChart.ChartAreas[0].AxisY.Minimum = 0.15;
            
         
            mainChart.ChartAreas[0].AxisY.ScaleBreakStyle = new AxisScaleBreakStyle
            {
                BreakLineStyle = BreakLineStyle.Ragged,
                Enabled = true,
                LineColor = Color.Gray
            };
        }

        protected virtual void DrawCurrentHour()
        {
            mainChart.ChartAreas[0].AxisY.StripLines.Clear();
            if (ShowCurrentHour)
            {
                if (m_timer == null)
                {
                    m_timer = new Timer { Interval = 10000, Enabled = true };
                    m_timer.Tick += TimerOnTick;
                }

                DateTime currentTime = DateTime.Now;
                StripLine stripLineHour = new StripLine
                {
                    IntervalOffsetType = DateTimeIntervalType.Hours,
                    IntervalOffset = currentTime.Hour / 24.0 + (currentTime.Minute / 1440.0),

                    StripWidth = 0.001,
                    Text = currentTime.ToShortTimeString(),
                    TextLineAlignment = StringAlignment.Near,
                    BackColor = CurrentHourColor
                };
                mainChart.ChartAreas[0].AxisY.StripLines.Add(stripLineHour);
            }
        }

        protected void DrawCurrentDay()
        {
            mainChart.ChartAreas[0].AxisX.StripLines.Clear();
           
            if (m_showCurrentDay)
            {
                StripLine stripLineToday = new StripLine
                {
                    IntervalOffset = DateTime.Today.ToOADate(),
                    StripWidth = .5,
                    Text = DateTime.Today.ToLongDateString(),
                    TextLineAlignment = StringAlignment.Near,
                    BackColor = CurrentDayColor
                };
                mainChart.ChartAreas[0].AxisX.StripLines.Add(stripLineToday);
            }
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            DrawCurrentHour();
        }

        private Series AddSunriseSerie(string caption, Color color)
        {
            return AddSerie("Sunrise", caption, color);
        }

        private Series AddSunsetSerie(string caption, Color color)
        {
            return AddSerie("Sunset", caption, color);
        }

        protected Series AddSerie(string name, string caption, Color color)
        {
            Series serie = MainChart.Series.Add(name);
            serie.LegendText = caption;          
            
            serie.Color = color;
            serie.BorderWidth = 1;//?
            serie.ChartType = SeriesChartType.Line;
            serie.XValueType = ChartValueType.Date;
            serie.YValueType = ChartValueType.Time;
            serie.MarkerStyle = MarkerStyle.None;
            serie.MarkerSize = 0;

            serie.ToolTip = "#VALX [#VALY{HH:mm:ss}]";
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
                    Text = "X = #VALX\nY = #VALY{HH:mm:ss}",
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
            DrawCurrent();
        }

        protected void DrawCurrent()
        {
            DrawCurrentDay();
            DrawCurrentHour();
        }

   

        private void chart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
        }

        private void chData_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            MainChart.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
            MainChart.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            MainChart.ChartAreas[0].CursorY.LineColor = Color.RoyalBlue;
            MainChart.ChartAreas[0].CursorX.LineColor = Color.RoyalBlue;
        }

        private void mainChart_DoubleClick(object sender, EventArgs e)
        {
            mainChart.Annotations.Clear();
        }
    }
}
