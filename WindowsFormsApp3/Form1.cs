using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    

    public partial class Form1 : Form
    {
        Data c = new Data();
        public Form1()
        {
           
            InitializeComponent();

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void chart2_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            
            float d = 0.01f;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.Minimum = c.x_ret(0);
            chart1.ChartAreas[0].AxisX.Maximum = c.x_ret(4);
            chart1.ChartAreas[0].AxisY.Minimum = -15;
            chart1.ChartAreas[0].AxisY.Maximum = 15;
            float y;
            for (float x = c.x_ret(0);x<c.x_ret(4);x+=d)
            {
                y = c.lagrangeInterpolation(x);
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }
        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            float d = 0.01f;
           // chart1.ChartAreas[0].AxisX.MajorGrid.Interval = d;
            float y;
            for (float x = c.x_ret(0); x < c.x_ret(4); x += d)
            {
                y = c.newtonInterpolation(x);
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
        }
    }
}
