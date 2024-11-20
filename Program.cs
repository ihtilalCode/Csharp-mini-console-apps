using System;

class Program
{
    static void Main()
    {
        
        Console.Write("A değerini girin: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("B değerini girin: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("C değerini girin: ");
        int c = Convert.ToInt32(Console.ReadLine());

        int toplam = a + b + c;

        if (toplam < 180)
        {
            Console.WriteLine("Bu bir üçgen değildir");
        }
        else if (toplam > 180)
        {
            Console.WriteLine("Bu bir üçgen değildir");
        }
        else
        {
            Console.WriteLine("Bu bir üçgendir");
        }
    }
}
