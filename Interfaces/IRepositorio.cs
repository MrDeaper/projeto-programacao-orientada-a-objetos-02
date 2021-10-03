using System.Collections.Generic;

namespace DIO.POO02.Interfaces
{
    public interface IRepositorio<T>
    {
        void Atualiza(int id, T entidade);
        void Exclui(int id);
        void Insere(T entidade);
        List<T> Lista();
        int ProximoId();
        T RetornaPorId(int id);
    }
}