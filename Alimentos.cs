using System;

namespace RepositorioAlimentos
{
    public class Alimentos : EntidadeBase
    {       
        private Classificacao classificacao{ get; set;}
        private string Descricao { get; set; }
        private string Fabricacao { get; set; }
        private string Validade { get; set; }
        private bool Excluido { get; set; }

        public Alimentos(int id, string marca, Classificacao classificacao, string descricao, string fabricacao, string validade, bool excluido)
        {
            this.Id = id;
            this.Marca = marca;
            this.classificacao = classificacao;
            this.Descricao = descricao;
            this.Fabricacao = fabricacao;
            this.Validade = validade;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Classificação: " + this.classificacao + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Data de fabricação: " + this.Fabricacao + Environment.NewLine;
            retorno += "Data de validade: " + this.Validade + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaMarca()
        {
            return this.Marca;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }

}