using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_ZD
{
    class Program
    {
        static double[,] test(int n) // заполнение матрицы
        {
            Random rand = new Random();
            double[,] M = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    M[i, j] = rand.Next(0, 100);
                }
            }
            return M;
        }
        static double Max(double[,] M)// нахождение максимального 
        {
            double max = M[0, 0];
            int n = (int)Math.Sqrt(M.Length);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (max < M[i, j])
                    {
                        max = M[i, j];
                    }
                }
            }
            return max;
        }
        static void PrintMatrix(double[,] M) // печать матрицы
        {
            int n = (int)Math.Sqrt(M.Length);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{M[i, j]}\t");
                }
                Console.WriteLine('\n');
            }
        }
        static double Check(bool mod = true, double inf = 1000)
        {
            double to = 0;
            bool flag = true;
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            while (flag)
            {
                try
                {
                    string from = Console.ReadLine();
                    to = Double.Parse(from.Replace(',', '.'), CultureInfo.InvariantCulture);
                    flag = false;
                    if (to < 0 && mod)
                    {
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка! Повторите ввод: ");
                }
                if (to == 0)
                {
                    flag = true;
                    Console.WriteLine("Ошибка! Повторите ввод: ");
                }
                if (to < 0)
                {
                    flag = true;
                    Console.WriteLine("Число меньше заданного диапазона!");
                }
                if (to > inf)
                {
                    flag = true;
                    Console.WriteLine("Число больше заданного диапазона!");
                }
            }
            return to;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете размер массива :");
            var n = (int)Check();
            var M = test(n);
            PrintMatrix(M);
            Console.WriteLine($"Максимум : {Max(M)}");
            Console.ReadKey();
        }
    }
}