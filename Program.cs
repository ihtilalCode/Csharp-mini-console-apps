using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma_10.hafta_1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bir sayı giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            int bolentoplam = 0;

            for (int i = 1; i < sayi; i++) 
            {
                if (sayi % i == 0)
                {
                    bolentoplam+=i;
                }
            }

            if (bolentoplam == sayi)
            {
                Console.WriteLine("Süper sayıdır.");
            }
            else
            {
                Console.WriteLine("Süper sayı değildir. ");
            }


        }
    }
}
