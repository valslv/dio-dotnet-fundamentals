using System;

class Desafio {
  
    static void Main() {
        double media, nota;
        double soma = 0;
        string entrada;
        int notasValidas = 0;

        while (notasValidas < 2 ) 
        {
          entrada = Console.ReadLine();
          nota = Convert.ToDouble(entrada, System.Globalization.CultureInfo.InvariantCulture);      
          if ( nota < 0 || nota > 10  ) 
          {
            Console.WriteLine("nota invalida");
          } else if (notasValidas < 1) 
          {
             soma += nota;
             notasValidas++;
          } 
          else if (notasValidas < 2)
          {
            soma += nota;
            media =  soma / 2;  
            Console.Write("media = ");
            Console.WriteLine(media.ToString("N2"));
            
            while ( true ){
              Console.WriteLine("novo calculo (1-sim 2-nao)");
              int.TryParse(Console.ReadLine(), out int res);
	
              if (res == 1) {
                notasValidas = 0;  
                soma = 0;               
                break;
              } else if (res == 2) {
                notasValidas = 3; 
                break;
              }
            }
          } 
        }
    }
}