using System;

class Program
{
    static void Main(string[] args)
    {
        string adSoyad = OgrenciBilgileriniAl();

        int ortalama = NotHesapla();


        Console.WriteLine($"{adSoyad} adlı öğrencinin not ortalaması: {ortalama}");
     }

    static string OgrenciBilgileriniAl()
    {
        Console.WriteLine("öğrenci adı ve soyadı: ");
     }


    static int NotHesapla()
    {
        Console.WriteLine("1. sınav notunu girin: ");
        int not1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("2. sınav notunu girin: ");
        int not2 = Convert.ToInt32(Console.ReadLine());

        int ortalama = (not1 + not2) / 2;
        return ortalama;    
    }
}
