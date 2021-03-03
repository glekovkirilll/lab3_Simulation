using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessModel;

namespace Flight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public Business businessModel;

        private void btStart_Click(object sender, EventArgs e)
        {
            businessModel = new Business((double)edAngle.Value, (double)edSpeed.Value, (double)edHeight.Value, (double)edSquare.Value, (double)edWeight.Value);

            var getCoordinates = businessModel.GetCoords();

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(getCoordinates.Item2, getCoordinates.Item3);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            var getParameters = businessModel.GetParameters();

            chart1.ChartAreas[0].AxisX.Maximum = getParameters.Item1 * 1.2;
            chart1.ChartAreas[0].AxisY.Maximum = getParameters.Item2 * 1.2;

            chart1.Series[0].Points.AddXY(getParameters.Item1, getParameters.Item3);

            if (getParameters.Item3 <= 0) timer1.Stop();

            TimeIndicator.Text = (getParameters.Item4).ToString();

        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }
    }
}
