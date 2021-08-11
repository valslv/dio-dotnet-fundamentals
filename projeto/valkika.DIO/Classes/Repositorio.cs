
using System;
using valkika.DIO.Interfaces;

namespace valkika.DIO
{
    public static class Repositorio
    {
        public static T Create<T>()
        {
            if (typeof(T) == typeof(IFilmeRepositorio))
            {
                return (T)(IFilmeRepositorio)new FilmeRepositorio();
            }
            else if (typeof(T) == typeof(ISerieRepositorio))
            {
                return (T)(ISerieRepositorio)new SerieRepositorio();
            }
            else
            {
                throw new NotImplementedException(String.Format("Creation of {0} interface is not supported yet.", typeof(T)));
            }
        }
    }
}