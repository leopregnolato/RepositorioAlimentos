using System;

namespace RepositorioAlimentos
{
    public class Alimentos : EntidadeBase
    {
        private string Descricao { get; set; }  
        private string Fabricacao { get; set; }
        private string Validade { get; set; }
        private bool Excluido { get; set; }

        public Alimentos(int id, string marca, string descricao, string fabricacao, string validade, bool excluido)
        {
            this.Id = id;
            this.Marca = marca;
            this.Descricao = descricao;
            this.Fabricacao = fabricacao;
            this.Validade = validade;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Descrição: " + this.Fabricacao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Validade + Environment.NewLine;
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
        public void Excluir() {
            this.Excluido = true;
        }

    }

}