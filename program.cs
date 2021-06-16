using System;

namespace RepositorioAlimentos
{
    class Program
    {
        static AlimentoRepositorio repositorio = new AlimentoRepositorio();
        static void Main(string Args[])
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAlimento();
						break;
					case "2":
						InserirAlimento();
						break;
					case "3":
						AtualizarAlimento();
						break;
					case "4":
						ExcluirAlimento();
						break;
					case "5":
						VisualizarAlimento();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirAlimento()
		{
			Console.Write("Digite o id do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAlimento);
		}

        private static void AtualizarAlimento()
		{
			Console.Write("Digite o id do Alimento: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite Marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Alimento: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a data de fabricação do alimento: ");
			int entradaFabricacao = int.Parse(Console.ReadLine());

			Console.Write("Digite a data de validade do alimento: ");
			string entradaValidade = Console.ReadLine();

			Serie atualizaAlimento = new Alimentos(id: indiceAlimento, marca: (Marca)entradaMarca, descricao: entradaDescricao, fabricacao: entradaFabricacao, validade: entradaValidade);
            

			repositorio.Atualiza(indiceAlimento, atualizaAlimento);
		}

        private static void ListarAlimento()
		{
			Console.WriteLine("Listar alimentos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum alimento cadastrado.");
				return;
			}

			foreach (var alimento in lista)
			{
                var excluido = alimento.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", alimento.retornaId(), alimento.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirAlimento()
		{
			Console.WriteLine("Inserir novo alimento");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Marca)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Marca), i));
			}
			Console.Write("Digite a marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Alimento: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a data de fabricação do alimento: ");
			int entradaFabricacao = int.Parse(Console.ReadLine());

			Console.Write("Digite a data de validade do alimento: ");
			string entradaValidade = Console.ReadLine();

            Alimento novoAlimento = new Alimentos(id: repositorio.ProximoId(), marca: (Marca)entradaMarca, descricao: entradaDescricao, fabricacao: entradaFabricacao, validade: entradaValidade);

			repositorio.Insere(novoAlimento);
		}
                  
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Guarda Alimentos lhe deseja Boas Vindas!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar alimentos");
            Console.WriteLine("2- Inserir novo alimento");
            Console.WriteLine("3- Atualizar alimento");
            Console.WriteLine("4- Excluir alimento");
            Console.WriteLine("5- Visualizar alimento");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}