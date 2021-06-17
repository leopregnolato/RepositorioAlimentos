using System.Collections.Generic;

namespace RepositorioAlimentos
{
    public interface IRepositorio<A>
    {
        List<A> GetLista();
        A RetornaPorId(int id);  
        void Insere(A entidade);        
        void Exclui(int id);        
        void Atualiza(int id, A entidade);
        int ProximoId();
    }
}