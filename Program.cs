using System;
class Program
{  
static void Main()
{
    Console.WriteLine("1. ders notunu girin: ");
    int not1 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("2.ders notunu girin : ");
    int not2 = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("3. ders notunu girin: ");
    int not3 = Convert.ToInt32(Console.ReadLine());

    double ortalama = (not1 + not2 + not3) / 3.0;

    Console.WriteLine($"Ortalama: {ortalama}");
    if (ortalama > 50)
    {
        Console.WriteLine("Dersi geçtiniz");

    }
    if (ortalama < 50)
    {
        Console.WriteLine("geçemediniz");
    }
}
}