using System.Collections.Generic;
using valkika.DIO.Interfaces;

namespace valkika.DIO
{
    public abstract class RepositorioBase<T>: IRepositorio<T> where T : EntidadeBase
    {
        protected static List<T> _lista = new List<T>();        
        public void Atualizar(int id, T entidade)
        {
            _lista[id] = entidade;
        }
        public abstract void Excluir(int id);      
        public void Inserir(T entidade)
        {
            _lista.Add(entidade);
        }
        public List<T> Lista()
        {
            return _lista;
        }
        public int ProximoId()
        {
            return _lista.Count;
        }
        public T RetornarPorId(int id)
        {
            return _lista[id];
        }
    }
}