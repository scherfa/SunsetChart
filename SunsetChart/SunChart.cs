using System;
using System.Linq;
using System.Windows.Forms;

namespace SunsetChart
{
    public partial class SunChart : Form
    {
        private readonly CityPositions m_cityPositions;
        private SunsetChartSettings m_chartSettings;
        public SunChart()
        {
            m_cityPositions = new CityPositions();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_chartSettings = SunsetChartSettings.Load();

            toolStripCities.Items.Clear();
            foreach (var cityPosition in m_cityPositions.Positions.OrderByDescending(c=>c.Country).ThenBy(c=>c.Caption))
            {
                toolStripCities.Items.Add(cityPosition.Caption);
            }

            var index = toolStripCities.Items.IndexOf(m_chartSettings.SelectedCity);
            toolStripCities.SelectedIndex = (index >= 0) ? index : 0;

            timeSunChartControl.ShowSunTime = true;
                      
            timeSunChartControl.ShowCurrentDay = m_chartSettings.ShowCurrentDay;
            riseFallSunChartControl.SummerWinterTime = m_chartSettings.ShowSummerWinterTimeOffset;
            riseFallSunChartControl.ShowCurrentDay = m_chartSettings.ShowCurrentDay;
            menuItemShowCurrentDay.Checked = m_chartSettings.ShowCurrentDay;
            menuItemSummerTime.Checked = m_chartSettings.ShowSummerWinterTimeOffset;
            RenderAll();
        }

        private void RenderAll()
        {
           riseFallSunChartControl.Render();
           timeSunChartControl.Render();
        }

        private void toolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityPosition position = m_cityPositions.GetCityPosition(toolStripCities.SelectedItem);

            riseFallSunChartControl.Position = position;
            timeSunChartControl.Position = position;
            RenderAll();
        }

        private void menuItemSummerTime_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                timeSunChartControl.SummerWinterTime= item.Checked;
                riseFallSunChartControl.SummerWinterTime = item.Checked;
                RenderAll();
            }
        }

        private void menuItemShowCurrentDay_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                item.Checked = !item.Checked;
                timeSunChartControl.ShowCurrentDay = item.Checked;
                riseFallSunChartControl.ShowCurrentDay = item.Checked;
            }
            RenderAll();
        }

        private void SunChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_chartSettings.ShowSummerWinterTimeOffset = menuItemSummerTime.Checked;
            m_chartSettings.ShowCurrentDay = riseFallSunChartControl.ShowCurrentDay;
            if (!string.IsNullOrEmpty(toolStripCities.SelectedText))
            {
                m_chartSettings.SelectedCity = toolStripCities.SelectedText;    
            }
            
            m_chartSettings.Save();

        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        private void beendenMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
