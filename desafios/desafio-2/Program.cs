using System;

class Desafio
{
    static void Main()
    {
        int quilometros;
        int.TryParse(Console.ReadLine(), out quilometros);
        int minutos = quilometros * 2; 
        Console.WriteLine(minutos + " minutos");
        Console.ReadLine();
    }
}

