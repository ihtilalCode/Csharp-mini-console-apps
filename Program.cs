using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma10.hafta_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sayı giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            int basamakSayisi = sayi.ToString().Length;
            int toplam = 0;
            int geciciSayi = sayi;


            while (geciciSayi > 0)
            {
                int basamakDegeri = geciciSayi % 10;
                toplam += (int)Math.Pow(basamakDegeri, basamakSayisi);
                geciciSayi /= 10;
            }


            if (toplam == sayi)
            {
                Console.WriteLine(sayi + " bir Armstrong sayısıdır.");
            }
            else
            {
                Console.WriteLine(sayi + " bir Armstrong sayısı değildir.");
            }
        }
    }
}
