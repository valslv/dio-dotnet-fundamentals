using System;

namespace valkika.DIO.Bank
{
    public class Conta
    {
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            _indexConta += 1;
            this.Numero = _indexConta;
        }
        private static int _indexConta = 0;
        public int Numero { get;}
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque <= (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorTransferencia, Conta contadestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contadestino.Depositar(valorTransferencia);
            }
        }
        
        public override string ToString()
        {
            return string.Format("TipoConta {0}| Nome {1}| Saldo {2}| Crédito {3}",                                  
                                 this.TipoConta, 
                                 this.Nome, 
                                 this.Saldo.ToString(), 
                                 this.Credito.ToString());
        }
    }

}