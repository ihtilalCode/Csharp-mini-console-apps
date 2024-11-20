using System;

class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Üçgenin 1. kenarını girin: ");
        int kenar1 = Convert.ToInt32(Console.ReadLine());
    
        Console.WriteLine("Üçgenin 2. kenarını girin: ");
        int kenar2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Üçgenin 3. kenarını girin: ");
        int kenar3 = Convert.ToInt32(Console.ReadLine());   

        int cevre = kenar1 + kenar2 + kenar3;

        Console.WriteLine("Üçgenin çevresi: " + cevre );
    }

}

