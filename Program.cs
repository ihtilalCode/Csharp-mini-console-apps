using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Birinci sayıyı giriniz: ");    // kullanıcıdan ilk sayıyı ister.
        double sayi1 = Convert.ToDouble(Console.ReadLine()); // girilen değer double türüne dönüştürülür.

        Console.WriteLine("İkinci sayıyı giriniz: ");     // aynı işlemi tekrar eder.
        double sayi2 = Convert.ToDouble(Console.ReadLine()); // sayı 2 değişkenine atar.

        double geometrikOrtalama = Math.Sqrt(sayi1 * sayi2); // iki sayının çarpımını ve ardından karekökünü alarak geometrik ortalamayı hesaplar

        Console.WriteLine($"Geometrik Ortalama: {geometrikOrtalama}"); // geometrik ortalamayı ekrana yazdırır. Değişkenin değerini mesajın içine yerleştirir.
    }
}
