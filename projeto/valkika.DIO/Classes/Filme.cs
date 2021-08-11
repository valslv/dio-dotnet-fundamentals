using System;

namespace valkika.DIO
{
    public class Filme : EntidadeBase
    {
        public Filme(int id, Genero genero, string titulo, string descricao, int ano, int duracao, TipoFilme tipo) : 
                      base (id, genero, titulo, descricao, ano)
        {
            this.Duracao = duracao;
            this.Tipo = tipo;
        }
        private int Duracao { get; set; }
        private TipoFilme Tipo { get; set; }

        public override string ToString()
        {
            return string.Format("{0}Duração: {1}Tipo:{2}",
                                 base.ToString(),
                                 this.Duracao + Environment.NewLine,
                                 this.Tipo
                                 );
        }
        
    }
}