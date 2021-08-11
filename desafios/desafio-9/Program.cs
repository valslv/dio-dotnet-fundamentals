using System;
using System.Collections.Generic;
using System.Linq;

class MinhaClasse {
  public static void Main (string[] args) {
    var totalDeCasosDeTeste = int.Parse(Console.ReadLine());
    
    for (int i = totalDeCasosDeTeste; i >= 1; i--)
    {
       int numeroCliente = int.Parse(Console.ReadLine());

       string[] entrada = Console.ReadLine().Split(' ');

       List<int> listaChegada = new List<int>();
       foreach (var numero in entrada)
       {
           listaChegada.Add(int.Parse(numero));
       }
       
       List<int> listaOrdenada = listaChegada.OrderByDescending(x => x).ToList();
      
       int naoTrocaram = 0;
       for (int l = 0; l < listaChegada.Count(); l++)
       {
           var posicao = listaOrdenada.IndexOf(listaChegada[l]);

           if (posicao == l)
               naoTrocaram++;
       }       
       Console.WriteLine(naoTrocaram);
    }   
    Console.ReadLine();
  }
}