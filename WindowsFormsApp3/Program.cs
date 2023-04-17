using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class Data
    {
        public float[] x;
        public float[] y;
        public Data() { x = new float[5]; y = new float[5];  }
        public void x_enter(int i, float a) { x[i] = a; }
        public void y_enter(int i, float a) { y[i] = a; }
        public float x_ret(int i) { return x[i]; }
        public float y_ret(int i) { return y[i]; }
        public float lagrangeInterpolation( float xp)
        {
            int n = 5;
            float intp = 0, m;
            int i, j;
            for (i = 0; i < n; i++)
            {
                m = 1;
                for (j = 0; j < n; j++)
                {
                    if (i != j) { m *= (xp - x[j]) / (x[i] - x[j]); }
                }
                m = m * y[i];
                intp = intp + m;
            }
            return intp;
        }
        static float u_cal(float u, int n)
        {
            float temp = u;
            for (int i = 1; i < n; i++)
                temp = temp * (u + i);
            return temp;
        }

        // Calculating factorial of given n
        static int fact(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
                f *= i;
            return f;
        }

        public float newtonInterpolation(float value)
        {
            int n = 5;
            float[,] y1=new float[n,n];
            for (int i = 0; i < n; i++) y1[i,0] = y[i];
            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                    y1[j, i] = y1[j, i - 1] - y1[j - 1, i - 1];
            }

            // Initializing u and sum
            float sum = y1[n - 1, 0];
            float u = (value - x[n - 1]) / (x[1] - x[0]);
            for (int i = 1; i < n; i++)
            {
                sum = sum + (u_cal(u, i) * y1[n - 1, i]) / fact(i);
            }
            return sum;
        }
        public float Interpolation(float xp)
        {
            return 1;
        }



    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
