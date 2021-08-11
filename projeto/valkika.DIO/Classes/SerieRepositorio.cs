using valkika.DIO.Interfaces;

namespace valkika.DIO
{
    public class SerieRepositorio : RepositorioBase<Serie>, ISerieRepositorio
    {
        public override void Excluir(int id)
        {
            _lista[id].Excluir();
        }        
   }
}