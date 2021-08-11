using System.Collections.Generic;

namespace valkika.DIO.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
         List<T> Lista();
         T RetornarPorId(int id);
         void Inserir(T entidade);
         void Excluir(int id);
         void Atualizar(int id, T entidade);
         int ProximoId();
    }
}