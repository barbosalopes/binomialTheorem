using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace binomialTheorem
{
    class Program
    {
        // Criar funções para calcular o fatorioal, o somatorio, a unidade do somatorio e o coeficiente

        public static double CalcBinomialCoeficient(double n, double p)
        {
            return CalcFat(n) / CalcFat(p) * CalcFat(n - p);
        }

        public static double CalcBinomialTheorem(double a, double b, int n)
        {
            double sum = 0;
            for (int p = 0; p < n; p++)
            {
                sum += CalcBinomialCoeficient(n, p) * Math.Pow(a, n-p) * Math.Pow(b, p);
            }
            return sum;
        }

        public static double CalcFat(double num)
        {
            double fat = 1;
            for(int i = 1; i <= num; i++)
            {
                fat *= i;
            }
            return fat;
        }
        
        public static int GetInt(string errorMessage)
        {
            int n;
            string s;
            Regex rgx = new Regex("^[0-9]+$");

            s = Console.ReadLine();
            while (!int.TryParse(s, out n) && !rgx.IsMatch(s))
            {
                Console.WriteLine(errorMessage);
                s = Console.ReadLine();
            }
            return n;
        }

        public static double GetDouble(string errorMessage)
        {
            double n;
            while(!double.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine(errorMessage);
            }
            return n;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 'a' value:");
            double a = GetDouble("a value is invalid");
            Console.WriteLine("Enter 'b' value:");
            double b = GetDouble("'b' value is invalid");
            Console.WriteLine("Enter 'n' value:");
            int n = GetInt("'n' value is invalid");
            double res = CalcBinomialTheorem(a, b, n);
            Console.WriteLine("Resultado: " + res);
            Console.ReadKey();
        }
    }
}
