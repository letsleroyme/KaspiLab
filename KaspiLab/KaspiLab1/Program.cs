using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaspiLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[10];
            int summ = 0;
            Random rand = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(0, 100);
                Console.Write($@"{mas[i]} ");
                summ += mas[i];
            }
            Console.WriteLine(); 
            for (int i = 0; i < mas.Length; i++)
            {
                if (IsEvenNumber(mas[i]))
                    Console.WriteLine($@"Четное число: {mas[i]}");

                if (IsSimpleNumber(mas[i]))
                    Console.WriteLine($@"Простое число: {mas[i]}");
            }
            Console.WriteLine($@"Сумма всех чисел: {summ}");



            Console.ReadKey();
        }
        /// <summary>
        /// Метод, определяющий четное ли число
        /// </summary>
        /// <param name="n">Число, которое нужно проверять</param>
        /// <returns>True - четное, false - нечетное</returns>
        private static bool IsEvenNumber(int n)
        { 
            return n % 2 == 0;
        }


        /// <summary>
        /// Метод, определяющий простое ли число
        /// </summary>
        /// <param name="n">Число, которое нужно проверять</param>
        /// <returns>True - четное, false - нечетное</returns>
        private static bool IsSimpleNumber(int n)
        {
            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                    if (n % i == 0) return false;
                return true;
            }
            return false;
        }
    }


  
}
