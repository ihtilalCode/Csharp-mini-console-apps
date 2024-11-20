using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lütfen rolünüzü seçin:");
        Console.WriteLine("1. Öğrenci");
        Console.WriteLine("2. Öğretmen");

        string secim = Console.ReadLine();

        if (secim == "1")
        {
            OgrenciDersleri();
        }
        else if (secim == "2")
        {

            OgretmenDersleri();
        }
        else
        {
            Console.WriteLine("Geçersiz seçim. Lütfen 1 veya 2'yi girin.");
        }
    }

    static void OgrenciDersleri()
    {
        Console.WriteLine("Seçtiğiniz dersler:");
        Console.WriteLine("- Algoritma");
        Console.WriteLine("- Yazılım Tasarım");
    }

    static void OgretmenDersleri()
    {
        Console.WriteLine("Seçtiğiniz dersler:");
        Console.WriteLine("- Elektronik");
        Console.WriteLine("- Fizik");
    }
}





