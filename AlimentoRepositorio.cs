using System.Collections.Generic;

namespace RepositorioAlimentos
{

    public class AlimentoRepositorio : IRepositorio<Alimentos>
    {
    private List<Alimentos> listaAlimentos = new List<Alimentos>();
        public void Atualiza(int id, Alimentos objeto)
        {
            listaAlimentos[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAlimentos[id].Excluir();
        }

        public List<Alimentos> GetLista()
        {
            throw new System.NotImplementedException();
        }

        public void Insere(Alimentos objeto)
        {
            listaAlimentos.Add(objeto);
        }

        public List<Alimentos> Lista()
        {
            return listaAlimentos;
        }
        public int ProximoId()
        {
            return listaAlimentos.Count;
        }

        public Alimentos RetornaPorId(int id)
        {
            return listaAlimentos[id];
        }

    }
}
