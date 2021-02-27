using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("É uma pena que você já vai embora :(. Volte logo!).");
            System.Console.WriteLine();
        }
        private static void ListarSeries()
        {
            System.Console.WriteLine("Lista das Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "-Excluido-": ""));
                
            }
        }
        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Por favor, escolha o gênero entre as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Qual o título da série?: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Em que ano foi lançado?: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite uma Sinopse: ");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Qual o id da série que você deseja atualizar");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Por favor, escolha o gênero entre as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Qual o título da série?: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Em que ano foi lançado?: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite uma Sinopse: ");
            string entradaDescricao = Console.ReadLine();
            Serie atualizaSerie = new Serie(id: indiceSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
           System.Console.WriteLine("Qual o id da série que você deseja Excluir");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
        private static void VisualizarSerie()
        {
           System.Console.WriteLine("Qual o id da série que você deseja Visualizar");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            System.Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Yours Series");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
