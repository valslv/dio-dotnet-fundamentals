using System;
using System.Collections.Generic;
using System.Linq;

class MinhaClasse {
  public static void Main (string[] args) {
    var totalDeCasosDeTeste = int.Parse(Console.ReadLine());
    
    if (totalDeCasosDeTeste > 100)
       return;

    List<string> listas = new List<string>();   

    for (int i = totalDeCasosDeTeste; i >= 1; i--)
    {
        listas.Add(Console.ReadLine());
    }
    
    foreach (string entrada in listas)
    {
        List<string> lista = entrada.Split(' ').ToList();
 
        var listaLimpa = lista.Distinct().ToList();

        listaLimpa.Sort();

        Console.WriteLine();
        listaLimpa.ForEach(item => Console.Write("{0} ", item));
    }
    Console.ReadLine();
  }
}