using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpolation
{
    public class Data
    {
        public float[] x;
        public float[] y;
        public Data() { x = new float[5]; y = new float[5]; }
        public void x_enter(int i, float a) { x[i] = a; }
        public void y_enter(int i, float a) { y[i] = a; }
        public float x_ret(int i) { return x[i]; }
        public float y_ret(int i) { return y[i]; }
        public float lagrangeInterpolation(float xp)
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

        public float newtonInterpolation(float t)
        {
            int n = 5;
            float res = y[0], F, den;
            int i, j, k;
            for (i = 1; i < n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j) den *= (x[j] - x[k]);
                    }
                    F += y[j] / den;
                }
                for (k = 0; k < i; k++) F *= (t - x[k]);
                res += F;
            }
            return res;
        }
        static float Power(float val, int p)
        {
            if (p == 0) return 1;
            if (p > 1) val *= Power(val, p - 1);
            return val;
        }
        public float InterpolationQu(float xp, int K)
        {
            int n = 10;
            int pts = 5;
            int k;
            float s, t, M;
            float[] a = new float[n];
            float[] b = new float[n];
            float[,] sums = new float[n, n];
            //упорядочиваем узловые точки по возрастанию абсцисс
            for (int i = 0; i < pts; i++)
            {
                for (int j = i; j >= 1; j--)
                    if (x[j] < x[j - 1])
                    {
                        t = x[j - 1]; x[j - 1] = x[j]; x[j] = t;
                        t = y[j - 1]; y[j - 1] = y[j]; y[j] = t;
                    }
            }
            //заполняем коэффициенты системы уравнений
            for (int i = 0; i < K + 1; i++)
            {
                for (int j = 0; j < K + 1; j++)
                {
                    sums[i, j] = 0;
                    for (k = 0; k < pts; k++)
                        sums[i, j] += Power(x[k], i + j);
                }
            }
            //заполняем столбец свободных членов
            for (int i = 0; i < K + 1; i++)
            {
                b[i] = 0;
                for (k = 0; k < pts; k++)
                    b[i] += Power(x[k], i) * y[k];
            }
            //применяем метод Гаусса для приведения матрицы системы к треугольному виду
            for (k = 0; k < K + 1; k++)
            {
                for (int i = k + 1; i < K + 1; i++)
                {
                    M = sums[i, k] / sums[k, k];
                    for (int j = k; j < K + 1; j++)
                        sums[i, j] -= M * sums[k, j];
                    b[i] -= M * b[k];
                }
            }
            //вычисляем коэффициенты аппроксимирующего полинома
            for (int i = K; i >= 0; i--)
            {
                s = 0;
                for (int j = i; j < K + 1; j++)
                    s += sums[i, j] * a[j];
                a[i] = (b[i] - s) / sums[i, i];
            }
            float res = 0;
            for (int j = 0; j <= K; j++) res += a[j] * Power(xp, j);
            return res;
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
