using System;

class Program
{ static void Main(string[] args)
    {
        Console.WriteLine("Karenin kenar uzunluğunu girin: ");
        int kenar = Convert.ToInt32(Console.ReadLine());

        int alan = kenar * kenar;

        Console.WriteLine("Karenin alanı: " + alan);

    }
}
