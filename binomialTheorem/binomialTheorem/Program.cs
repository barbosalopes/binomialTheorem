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

        /// <summary>
        /// Calculate the binomial coeficient.
        /// </summary>
        /// <param name="n">'n' value.</param>
        /// <param name="p">'p' value.</param>
        /// <returns>Binomial coeficient.</returns>
        public static double CalcBinomialCoeficient(double n, double p)
        {
            return CalcFat(n) / (CalcFat(p) * CalcFat(n - p));
        }

        /// <summary>
        /// Calculate the binomial theorem.
        /// </summary>
        /// <param name="a">'a' value.</param>
        /// <param name="b">'b' value.</param>
        /// <param name="n">'n' value.</param>
        /// <returns>Binomial theorem.</returns>
        public static double CalcBinomialTheorem(double a, double b, int n)
        {
            double sum = 0;
            for (int p = 0; p < n; p++)
            {
                sum += CalcBinomialCoeficient(n, p) * Math.Pow(a, n-p) * Math.Pow(b, p);
            }
            return sum;
        }

        /// <summary>
        /// Calculate the fatorial.
        /// </summary>
        /// <param name="num">Base number to calculate the fatorial.</param>
        /// <returns>Fatorial.</returns>
        public static double CalcFat(double num)
        {
            double fat = 1;
            for(int i = 1; i <= num; i++)
            {
                fat *= i;
            }
            return fat;
        }
        
        /// <summary>
        /// Get a valid integer number from the user.
        /// </summary>
        /// <param name="errorMessage">Message to be show when the input number is not a integer.</param>
        /// <returns>The integer number.</returns>
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

        /// <summary>
        /// Get a valid double number from the user.
        /// </summary>
        /// <param name="errorMessage">Message to be show when the input number is not a double.</param>
        /// <returns></returns>
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
            Console.WriteLine("Welcome! This project calculates the binomial thorem.");
            Console.WriteLine("To calculate then you must inster the 'a', 'b' and 'n' value. So lets Begin!");
            Console.WriteLine("Enter 'a' value (Must be a Real number):");
            double a = GetDouble("The a value is invalid!");    

            Console.WriteLine("Enter 'b' value (Must be a Real number):");
            double b = GetDouble("'b' value is invalid");

            Console.WriteLine("Enter 'n' value (Must be a Integer number):");
            int n = GetInt("'n' value is invalid");

            double res = CalcBinomialTheorem(a, b, n);
            Console.WriteLine("Resultado: " + res);
            Console.ReadKey();
        }
    }
}
