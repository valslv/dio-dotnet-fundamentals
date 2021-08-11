using System;

class Classe
{
    static void Main()
    {
        int h, p;
        string[] line = Console.ReadLine().Split(" ");
        int.TryParse(line[0], out h);
        int.TryParse(line[1], out p);

        double media = ((double)h / (double)p);

        Console.WriteLine(string.Format("{0:0.00}", media));
        Console.ReadLine();
    }    
}