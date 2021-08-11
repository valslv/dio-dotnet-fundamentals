using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha))
                break;
                
            string pattern = ("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{6,32}$");
            bool senhaValida = Regex.IsMatch(senha, pattern);
            Console.WriteLine(senhaValida ? "Senha valida." : "Senha invalida.");                
        }
    }
}
