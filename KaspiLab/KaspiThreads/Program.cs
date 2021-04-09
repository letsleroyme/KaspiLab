using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KaspiThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Входная строка:");
            string input_string = Console.ReadLine();
            Console.WriteLine("Количество потоков:");
            int TaskCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Количество вычислений, которое нужно сделать:");
            int ComputeCount = int.Parse(Console.ReadLine());


            Task<string>[] tasks = new Task<string>[TaskCount];

            for (int i = 0; i < TaskCount; i++)
            {
                Console.WriteLine($"Старт {i} потока.");
                Task.Factory.StartNew(() => GetMD5(input_string, ComputeCount));
            }
            Task.WaitAll();
            Console.ReadKey();
        }


        static void GetMD5(string input, int count = 1)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            Console.WriteLine(Convert.ToBase64String(hash));

            Console.WriteLine();
            for (int i = 1; i < count; i++)
            {
                hash = md5.ComputeHash(hash);
                Console.WriteLine(Convert.ToBase64String(hash));
            }

            Console.WriteLine(Convert.ToBase64String(hash));
        }

    }
}
