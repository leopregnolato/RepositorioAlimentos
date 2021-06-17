using System;

namespace RepositorioAlimentos
{
    class Program
    {
        static AlimentoRepositorio repositorio = new AlimentoRepositorio();
        static void Main(string[] args)
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

			Console.WriteLine("Obrigado por utilizar nossos serviços. Volte Sempre!");
			Console.ReadLine();
        }

        private static void ExcluirAlimento()
		{
			Console.Write("Digite o ID do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("TEM CERTEZA que deseja excluir o alimento com o ID {0}?");
			Console.WriteLine();
			Console.Write("Digite [S] para SIM e [N] para NÃO:");
			Console.WriteLine();
			string decisao = Console.ReadLine().ToUpper();
			if(decisao == "S")
			{
				repositorio.Exclui(indiceAlimento);
				Console.WriteLine();
				Console.Write("Alimento excluído com sucesso!");
				Console.WriteLine();
			}
			else if(decisao == "N")
			{
				Console.WriteLine();
				Console.Write("O alimento com ID {0} não foi excluído.", indiceAlimento);
				Console.WriteLine();
			}
			else{
				throw new ArgumentOutOfRangeException();
			}
			
		}

		private static void VisualizarAlimento()
		{
			Console.Write("Digite o ID do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());

			var alimento = repositorio.RetornaPorId(indiceAlimento);

			Console.WriteLine(alimento);
		}


        private static void AtualizarAlimento()
		{
			Console.Write("Digite o ID do alimento: ");
			int indiceAlimento = int.Parse(Console.ReadLine());

			Console.Write("Digite a MARCA do alimento: ");
			string entradaMarca = Console.ReadLine();
			Console.WriteLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.WriteLine();
			Console.Write("Digite o numero para a CLASSIFICAÇÃO entre as opções acima: ");
			int entradaClass = int.Parse(Console.ReadLine());

			Console.Write("Digite a DESCRIÇÃO do Alimento: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a DATA DE FABRICAÇÃO (mm/aaaa) do alimento: ");
			string entradaFabricacao = Console.ReadLine();

			Console.Write("Digite a DATA DE VALIDADE (mm/aaaa) do alimento: ");
			string entradaValidade = Console.ReadLine();

			Alimentos atualizaAlimento = new Alimentos(
                id: indiceAlimento,
                marca: entradaMarca,
				classificacao: (Classificacao)entradaClass,
                descricao: entradaDescricao,
                fabricacao: entradaFabricacao,
                validade: entradaValidade,
                excluido: false);
            

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
                
				Console.WriteLine("#ID {0}: - {1} {2}", alimento.retornaId(), alimento.retornaMarca(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirAlimento()
		{
			Console.WriteLine("Inserir novo alimento");

			Console.Write("Digite a MARCA do alimento: ");
			string entradaMarca = Console.ReadLine();
			Console.WriteLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.WriteLine();
			Console.Write("Digite o numero para a CLASSIFICAÇÃO entre as opções acima: ");
			int entradaClass = int.Parse(Console.ReadLine());

			Console.Write("Digite a DESCRIÇÃO do alimento: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a DATA DE FABRICAÇÃO (mm/aaaa) do alimento: ");
			string entradaFabricacao = Console.ReadLine();

			Console.Write("Digite a DATA DE VALIDADE (mm/aaaa) do alimento: ");
			string entradaValidade = Console.ReadLine();

            var novoAlimento = new Alimentos(
                id: repositorio.ProximoId(),
                marca: entradaMarca,
				classificacao: (Classificacao)entradaClass,
                descricao: entradaDescricao,
                fabricacao: entradaFabricacao,
                validade: entradaValidade,
                excluido: false);

			repositorio.Insere(novoAlimento);
		}
                  
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
			Console.WriteLine("•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•");
            Console.WriteLine("• DIO Estoque de Alimentos lhe deseja Boas Vindas!     •");
            Console.WriteLine("• Veja as opções:                                      •");
			Console.WriteLine("•                                                      •");
            Console.WriteLine("• 1- Listar alimentos                                  •");
            Console.WriteLine("• 2- Inserir novo alimento                             •");
            Console.WriteLine("• 3- Atualizar alimento                                •");
            Console.WriteLine("• 4- Excluir alimento                                  •");
            Console.WriteLine("• 5- Visualizar alimento                               •");
            Console.WriteLine("• C- Limpar Tela                                       •");
            Console.WriteLine("• X- Sair                                              •");
			Console.WriteLine("•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•*´¨`*•.¸¸.•");
            Console.WriteLine();

			Console.WriteLine("Digite a sua opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}