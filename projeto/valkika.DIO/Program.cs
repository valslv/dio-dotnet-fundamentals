using System;
using valkika.DIO.Interfaces;

namespace valkika.DIO
{
    class Program
    {
        static dynamic repositorio;
        private static CategoriaVideo categoriaVideo { get; set; }
        static void Main(string[] args)
        {
            ApresentarOpcoes();
        }
        #region Menu
        private static void ApresentarOpcoes()
        {
            string opcaoUsuario = ObterOpcaoUsuario(); 

            while (!opcaoUsuario.Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:    
                        throw new ArgumentOutOfRangeException();
                }           
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static void SelecionarCategoria()
        {
            Console.WriteLine("1 - Filme");
            Console.WriteLine("2 - Série");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            
            switch (opcaoUsuario)
            {
                case "1":
                    categoriaVideo = CategoriaVideo.Filme;
                    break;
                case "2":
                    categoriaVideo = CategoriaVideo.Serie;
                    break;
                default:     
                    categoriaVideo = CategoriaVideo.None;
                    break;
            }
        }
        private static void CriarRepositorio()
        {
            if (categoriaVideo == CategoriaVideo.Filme)
                repositorio = Repositorio.Create<IFilmeRepositorio>();
            else
                repositorio = Repositorio.Create<ISerieRepositorio>();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("valkika stream a seu dispor...");
            Console.WriteLine("Informe a opção desejada:");

            while (categoriaVideo == CategoriaVideo.None)
            {
               SelecionarCategoria();
            }

            CriarRepositorio();

            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Inserir");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");
            Console.WriteLine("5 - Visualizar");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");

            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        public static int ApresentarGenero()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            return int.Parse(Console.ReadLine());
        } 
        #endregion
        
        #region Opções 
        private static void Visualizar()
        {
            Console.WriteLine("Visualizar um vídeo");
            Console.WriteLine("Digite o ID:");
            int id = int.Parse(Console.ReadLine());            
            Console.WriteLine(repositorio.RetornarPorId(id));
        }
        private static void Excluir()
        {
            Console.WriteLine("Apagar um vídeo");
            Console.WriteLine("Digite o ID:");
            int id = int.Parse(Console.ReadLine());
            repositorio.Excluir(id);
        }
        private static void Atualizar()
        {
            Console.WriteLine("Atualizar um vídeo");
            Console.WriteLine("Digite o ID:");
            int id = int.Parse(Console.ReadLine());
            if (categoriaVideo == CategoriaVideo.Serie)
               repositorio.Atualizar(id, PedirSerieUsuario(id));
            else
               repositorio.Atualizar(id, PedirFilmeUsuario(id));
        }
        private static void Inserir()
        {
            if (categoriaVideo == CategoriaVideo.Serie)
                InserirSerie();
            else 
                InserirFilme(); 
        }
        private static void Listar()
        {
            Console.WriteLine("Listar vídeos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Sem vídeos cadastrados");
                return;
            }

            foreach (var video in lista) 
            {
                Console.WriteLine("#ID {0}: - {1} {2}", 
                                  video.RetornarId(), 
                                  video.RetornarTitulo(), 
                                  (video.RetornarExcluido() ? "*Excluido*": string.Empty));
            }   
        }
        #endregion
        
        #region Serie
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            Serie serie = PedirSerieUsuario(repositorio.ProximoId());
            repositorio.Inserir(serie);
        }
        private static Serie PedirSerieUsuario(int id)
        {
            int entradaGenero = ApresentarGenero();

            Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicío da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite uma descrição para da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o total de episodios da série: ");
            int entradaTotaEpisodios = int.Parse(Console.ReadLine());

            Console.Write("Digite a temporada da série: ");
            int entradaTemporada = int.Parse(Console.ReadLine());

            var serie = new Serie(id, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno, entradaTotaEpisodios, entradaTemporada);
            return serie;
        }
        #endregion

        #region Filme
        public static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");
            Filme filme = PedirFilmeUsuario(repositorio.ProximoId());
            repositorio.Inserir(filme);
        }
        private static Filme PedirFilmeUsuario(int id)
        {
            int entradaGenero = ApresentarGenero();

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite uma descrição para o Filme: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a duração do filme em minutos: ");
            int entradaDuracaoFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(TipoFilme)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TipoFilme), i));
            }

            Console.Write("Digite o Tipo de filme entre as opções acima: ");
            int entradaTipo = int.Parse(Console.ReadLine());

            var filme = new Filme(id, (Genero)entradaGenero, entradaTitulo, entradaDescricao, 
                                  entradaAno, entradaDuracaoFilme, (TipoFilme)entradaTipo);
            return filme;
        }        

        #endregion
    }
}