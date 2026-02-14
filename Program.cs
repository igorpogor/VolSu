using System;
using System.Collections.Generic;
using System.Globalization;

namespace CSharpLab
{
    class Program
    {
        static double CalculateF(double x, double y)
        {
            double x2 = x * x;
            double baseValue = (x2 + y) * (x2 + y);
            double xy = x * y;

            if (xy > 0)
            {
                return baseValue - Math.Sqrt(x2 * y);
            }
            else if (xy < 0)
            {
                return baseValue - Math.Sqrt(Math.Abs(x2 * y));
            }
            else
            {
                return baseValue + 1;
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (input == null) 
                {
                    Environment.Exit(0);
                }
                input = input.Replace('.', ',');
                double result;
                if (double.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода. Попробуйте снова.");
            }
        }

        static void Main(string[] args)
        {
            double x = ReadDouble("Введите x: ");
            double y = ReadDouble("Введите y: ");
            double n = 0;
            while (n <= 0)
            {
                n = ReadDouble("Введите шаг n (> 0): ");
                if (n <= 0)
                    Console.WriteLine("Шаг должен быть положительным числом.");
            }

            List<double> results = new List<double>();

            Console.WriteLine();
            Console.WriteLine("{0,-5} {1,-20} {2,-25}", "i", "x", "f(x, y)");
            Console.WriteLine(new string('-', 50));

            int i = 0;
            double currentX = x;
            double endX = x + 10.0;

            while (currentX <= endX + 1e-9)
            {
                double f = CalculateF(currentX, y);
                results.Add(f);
                i++;
                Console.WriteLine("{0,-5} {1,-20:F6} {2,-25:F6}", i, currentX, f);
                currentX = x + i * n;
            }

            Console.WriteLine();
            Console.WriteLine("Результаты сохранены в массив из {0} элементов.", results.Count);
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}