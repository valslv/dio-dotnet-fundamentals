using System;
using System.Collections.Generic;

namespace valkika.DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();
            
            while (!opcaoUsuario.Equals("X"))
            {
                switch (opcaoUsuario)
                {
                   case "1":
                    ListarContas();
                    break;

                   case "2":
                    InserirConta(); 
                    break;

                   case "3":
                    TransferirConta();
                    break;

                   case "4":
                    SacarConta();
                    break;

                   case "5":
                    DespositarConta();
                    break;

                   case "C":
                    Console.Clear();                   
                    break;

                   default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("krikas Bank a seu dispor...");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (Conta conta in listaContas)
            {
                Console.Write("#{0} -", conta.Numero);
                Console.WriteLine(conta);
            }

        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.Write("Digite 1 para Conta Pessoa Física ou 2 para Jurídica: ");
            int entradaTipoConta;
            int.TryParse(Console.ReadLine(), out entradaTipoConta);

            Console.Write("Informe o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Informa o saldo inicial: ");
            double entradaSaldo;
            double.TryParse(Console.ReadLine(), out entradaSaldo);

            Console.Write("Informa o crédito: ");
            double entradaCredito;
            double.TryParse(Console.ReadLine(), out entradaCredito);

            var novaConta = new Conta(
                (TipoConta)entradaTipoConta, 
                entradaSaldo, 
                entradaCredito, 
                entradaNome
            );

            listaContas.Add(novaConta);
        }
        private static void TransferirConta()
        {
            Console.Write("Digite o numero da Conta de origem: ");
            int entradaNumeroContaOrigem;
            int.TryParse(Console.ReadLine(), out entradaNumeroContaOrigem);

            Console.Write("Digite o numero da Conta de destino: ");
            int entradaNumeroContaDestino;
            int.TryParse(Console.ReadLine(), out entradaNumeroContaDestino);

            Console.Write("Digite o valor a ser transferido: ");
            double entradaValorTransferencia;
            double.TryParse(Console.ReadLine(), out entradaValorTransferencia);

            var contaDestino = listaContas.Find(x => x.Numero == entradaNumeroContaDestino);
            var contaOrigem = listaContas.Find(x => x.Numero == entradaNumeroContaOrigem);

            if (contaDestino == null)
            {
                Console.Write("Conta de destino não encontrada");
                return;
            } 

            if (contaOrigem == null)
            {
                Console.Write("Conta de origem não encontrada");
                return;
            } 

            contaOrigem.Transferir(entradaValorTransferencia, contaDestino);
        }
        private static void DespositarConta()
        {
            Console.Write("Digite o numero da Conta: ");
            int entradaNumeroConta;
            int.TryParse(Console.ReadLine(), out entradaNumeroConta);

            Console.Write("Digite o valor a ser despositado: ");
            double entradaValorDeposito;
            double.TryParse(Console.ReadLine(), out entradaValorDeposito);

            var conta = listaContas.Find(x => x.Numero == entradaNumeroConta);
            conta?.Depositar(entradaValorDeposito);
        }
        private static void SacarConta()
        {
            Console.Write("Digite o numero da Conta: ");
            int entradaNumeroConta;
            int.TryParse(Console.ReadLine(), out entradaNumeroConta);

            Console.Write("Digite o valor a ser sacado: ");
            double entradaValorSaque;
            double.TryParse(Console.ReadLine(), out entradaValorSaque);

            var conta = listaContas.Find(x => x.Numero == entradaNumeroConta);
            conta?.Sacar(entradaValorSaque);
        }

    }
}
