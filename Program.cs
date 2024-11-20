using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma10.hafta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz: ");
            int sayi =Convert.ToInt32(Console.ReadLine());

            int toplam = 0;
            for (int i = 0; i < sayi; i++)
            {
                toplam += i;
            }  
            Console.WriteLine(toplam);
        }
    }
}
