using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Interpolation
{
    public partial class Form1 : Form
    {
        Data c=new Data();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                float a = float.Parse(textBox1.Text);
                c.x_enter(0, a);
                a = float.Parse(textBox2.Text);
                c.y_enter(0, a);
                a = float.Parse(textBox3.Text);
                c.x_enter(1, a);
                a = float.Parse(textBox4.Text);
                c.y_enter(1, a);
                a = float.Parse(textBox5.Text);
                c.x_enter(2, a);
                a = float.Parse(textBox6.Text);
                c.y_enter(2, a);
                a = float.Parse(textBox7.Text);
                c.x_enter(3, a);
                a = float.Parse(textBox8.Text);
                c.y_enter(3, a);
                a = float.Parse(textBox9.Text);
                c.x_enter(4, a);
                a = float.Parse(textBox10.Text);
                c.y_enter(4, a);
            }
            catch(System.FormatException)
            {
                 MessageBox.Show(
        "Wrong data", 
        "Error", 
        MessageBoxButtons.OK, 
        MessageBoxIcon.Information, 
        MessageBoxDefaultButton.Button1, 
        MessageBoxOptions.DefaultDesktopOnly);
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;

            float d = 0.01f;

            float y;
            for (float x = -2; x <= 5; x += d)
            { 
                y = c.lagrangeInterpolation(x);
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        
        }

    private void button3_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;
            float d = 0.5f;

            float y;
            for (float x = -2; x <= 5; x += d)
            {
                y = c.newtonInterpolation(x);
                this.chart1.Series[1].Points.AddXY(x, y);
            }
            
           
         //   label8.Text = err.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;
            float d = 0.01f;

            float y;
            for (float x = -2; x <= 5; x += d)
            {
                y = c.InterpolationQu(x, 1);
                this.chart1.Series[2].Points.AddXY(x, y);
            }
            
            
         //   label8.Text = err.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            float d = 0.01f;
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;


            float y;
            for (float x = -2; x <= 5; x += d)
            {
                y = c.InterpolationQu(x, 2);
                this.chart1.Series[3].Points.AddXY(x, y);
            }
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            float d = 0.01f;
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;


            float y;
            for (float x = -2; x <= 5; x += d)
            {
                y = c.InterpolationQu(x, 3);
                this.chart1.Series[4].Points.AddXY(x, y);
            }
           
         //   label8.Text = err.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;



            float y;
            
                try
            {
                float a = float.Parse(textBox11.Text);
                
                float b = float.Parse(textBox12.Text);
                
                float c1 = float.Parse(textBox13.Text);
   
                float d = float.Parse(textBox14.Text);

                float e1 = float.Parse(textBox15.Text);

                float delta = 0.01f;

                
                for (float x = -2; x <= 5; x += delta)
                {
                    y = a * (float)Math.Pow(x, 4) + b * (float)Math.Pow(x, 3) + c1 * (float)Math.Pow(x, 2) + d*x+e1;
                    this.chart1.Series[5].Points.AddXY(x, y);
                }
                
            }
            catch (System.FormatException)
            {
                MessageBox.Show(
       "Wrong data",
       "Error",
       MessageBoxButtons.OK,
       MessageBoxIcon.Information,
       MessageBoxDefaultButton.Button1,
       MessageBoxOptions.DefaultDesktopOnly);
            }
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.Interval = 4;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 20;
            chart1.ChartAreas[0].AxisY.Minimum = -50;

            for (int i = 0; i < 5; i++) this.chart1.Series[6].Points.AddXY(c.x_ret(i), c.y_ret(i));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();
            chart1.Series[6].Points.Clear();
        }

        
    }
}
