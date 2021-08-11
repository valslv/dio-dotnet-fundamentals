using System;

namespace valkika.DIO
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano, int totalEpisodios, int temporada) : 
                      base (id, genero, titulo, descricao, ano)
        {
            this.Temporada = temporada;
            this.TotalEpisodios = totalEpisodios;
        }
        private int TotalEpisodios { get; set; }
        private int Temporada { get; set; }

        public override string ToString()
        {
            return string.Format("{0}Temporada: {1}Episódios:{2}",
                                 base.ToString(),
                                 this.Temporada + Environment.NewLine,
                                 this.TotalEpisodios
                                 );
        }
    }
}