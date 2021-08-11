using System;

namespace desafio_1
{
    class Desafio
    {
        static void Main()
        {
            int limit;
            if (!int.TryParse(Console.ReadLine(), out limit))
                limit = 2;

            double X, Y;
            for (int i = 0; i < limit; i++)
            {
                string[] line = Console.ReadLine().Split(" ");

                double.TryParse(line[0], out X);

                if (line.Length < 2)
                {
                    Console.WriteLine("divisao impossivel");
                    continue;
                }

                double.TryParse(line[1], out Y);
                if (Y == 0)
                {
                    Console.WriteLine("divisao impossivel");
                }
                else
                {
                    double divisao = X / Y;
                    Console.WriteLine(divisao.ToString("N1"));
                }
            }
        }
    }
}
