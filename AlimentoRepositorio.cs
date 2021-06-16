namespace RepositorioAlimentos{
    
    public class AlimentoRepositorio : IRepositorio<Alimento>
    {
        private List<Alimento> listaAlimentos = new List<Alimento>();
        public void Atualiza(int id, Alimento objeto)
        {
            listaAlimentos[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAlimentos[id].Exclui();
        }

        public void Insere(Alimento objeto)
        {
            listaAlimentos.Add(objeto);
        }

        public List<Alimento> Lista => listaAlimentos;

        public int ProximoId()
        {
            return listaAlimentos.Count;
        }

        public Alimento RetornaPorId()
        {
            return listaAlimentos[id];
        }

    }
}
