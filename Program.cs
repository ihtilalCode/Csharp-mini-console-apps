using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_Kasım_Algoritma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ogrenciListe = new List<string>();

            int ogrencisayi = 0;
            Console.WriteLine("Öğrenci eklemek için 1e hayır ise 2ye basın: ");

            while (true)
            {
                int karar = 0;

                karar = Convert.ToInt32(Console.ReadLine());

                if (karar == 1)
                {
                    Console.WriteLine("Katılacak Öğrenci ismi giriniz: ");
                    ogrenciListe.Add(Console.ReadLine());
                    ogrencisayi++;
                    Console.WriteLine("Karar değeri giriniz. Devam 1 yoksa 2 . ");
                }
                else if (karar == 2)
                {
                    Console.WriteLine("Ekleme işlemi bitti. Toplam eklenen kişi sayısı " + ogrencisayi);
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz değer girdiniz tekrar deneyin. ");
                }
            }
        }
    }
}
