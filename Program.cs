using System;
class Program
{
    static void Main()
    {
        Console.Write("Adınızı girin: "); //kullanıcı metin girer.
        string ad = Console.ReadLine();  //girilen metni string değişkenine atar.

        Console.Write("Soyadınızı girin: "); // aynı işlemler tekrarlanır.
        string soyad = Console.ReadLine();

        Console.Write("Öğrenci numaranızı girin: ");
        string ogrenciNo = Console.ReadLine();

        Console.Write("Telefon numaranızı girin: ");
        string telefonNo = Console.ReadLine();

        Console.WriteLine("\nKullanıcı Bilgileri:"); //konsola satır yazdırılır.
        Console.WriteLine($"Ad: {ad}");             //kullanıcıdan alınan bilgiler {} içinde konsola yazdırılır.
        Console.WriteLine($"Soyad: {soyad}");
        Console.WriteLine($"Öğrenci No: {ogrenciNo}");
        Console.WriteLine($"Telefon No: {telefonNo}");

    }
}
