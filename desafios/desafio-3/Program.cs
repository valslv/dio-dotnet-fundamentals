using System;

namespace desafio_3
{
    class Desafio
    {
        static void Main()
        {
            const int totalConvidados = 5;
            int[] convidados = {300, 1500, 600, 1000, 150};
            int total = 225;
            for (int i = 0; i < totalConvidados; i++)
            {
                total += (convidados[i] * StrToIntDef(Console.ReadLine(), 1));
            }
            Console.WriteLine(total);
            Console.ReadLine();
        }

        public static int StrToIntDef(string value, int @default)
        {
            if (int.TryParse(value, out int number))
                return number;
            return @default;
        }
    }
}
