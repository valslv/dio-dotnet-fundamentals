using System;

namespace valkika.DIO
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {

        } 
        public EntidadeBase(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public int Id {get; protected set;}        
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public override string ToString()
        {
            return string.Format("Genero: {2}Título: {1}Descrição: {2}Ano de início: {3}Excluído: {4}",
                                 Enum.GetName(typeof(Genero), this.Genero) + Environment.NewLine,
                                 this.Titulo + Environment.NewLine,
                                 this.Descricao + Environment.NewLine,
                                 this.Ano + Environment.NewLine,
                                 this.Excluido);
        }
        public string RetornarTitulo() => this.Titulo;        
        public int RetornarId() => this.Id;
        public void Excluir() => this.Excluido = true;
        public bool RetornarExcluido() => this.Excluido;
    }
}