using System;
using System.Drawing;
using System.Windows.Forms;

namespace SunsetChart
{
    public partial class SunChartSettings : Form
    {
        public SunChartSettings()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            currentDayColorButton.BackColor = Color.FromArgb(SunsetChartSettings.Instance.CurrentDayColor);
            currentHourColorButton.BackColor = Color.FromArgb(SunsetChartSettings.Instance.CurrentHourColor);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button colorButton = (Button)sender;
            ColorDialog cdl = new ColorDialog();
            cdl.FullOpen = true;
            
            cdl.Color = colorButton.BackColor;
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = cdl.Color;
                switch (colorButton.Name)
                {
                    case "currentDayColorButton":
                        SunsetChartSettings.Instance.CurrentDayColor = cdl.Color.ToArgb();
                        break;
                    case "currentHourColorButton":
                        SunsetChartSettings.Instance.CurrentHourColor = cdl.Color.ToArgb();
                        break;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
