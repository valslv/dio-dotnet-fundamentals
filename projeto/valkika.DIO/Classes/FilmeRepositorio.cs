
using valkika.DIO.Interfaces;

namespace valkika.DIO
{
    public class FilmeRepositorio: RepositorioBase<Filme>, IFilmeRepositorio
    {       
        public override void Excluir(int id)
        {
            _lista[id].Excluir();
        }        
    }
}