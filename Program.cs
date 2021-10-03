using System;

namespace DIO.POO02
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
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
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.............Obrigado Por Utilizar Nossos Serviços.............|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.........................Listar Séries.........................|");
            Console.WriteLine("+===============================================================+");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("|...................Nenhuma  Série Cadastrada...................|");
                Console.WriteLine("+===============================================================+");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                //MODO DO PROFESSOR - Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluido" : ""); //O excluido ? gera um true e false dentro do próprio Console
                if(excluido == false){
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                else{
                    Console.WriteLine("#ID {0}: - EXCLUIDO", serie.retornaId());
                }
            }

            Console.WriteLine("+===============================================================+");
        }

        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.........................Inserir Série.........................|");
            Console.WriteLine("+===============================================================+");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("| {0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.............Digite o Gênero Entre as Opções Acima.............|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|...................Digite  o Título da Série...................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|................Digite o Ano de Início da Série................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|..................Digite a Descrição da Série..................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.....................Digite  o Id da Série.....................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|........................Atualizar Série........................|");
            Console.WriteLine("+===============================================================+");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("| {0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.............Digite o Gênero Entre as Opções Acima.............|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|...................Digite  o Título da Série...................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|................Digite o Ano de Início da Série................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|..................Digite a Descrição da Série..................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

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
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.........Digite  o Id da Série Que Você Deseja Excluir.........|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("| #ID {0}: - {1} - Deseja  Mesmo Excluir Está Série?", serie.retornaId(), serie.retornaTitulo());
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|........................1. SIM | 2. NÃO........................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int escolha = int.Parse(Console.ReadLine());

            if(escolha == 2){
                return;
            }
            else if(escolha == 1){
                repositorio.Exclui(indiceSerie);
                return;
            }
            else{
                throw new ArgumentOutOfRangeException();
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.....................Digite  o Id da Série.....................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine(serie);
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("|.......................SÉRIES DO JUANITO.......................|");
            Console.WriteLine("|...................Informe  a Opção Desejada...................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine("| 1. Listar Séries..............................................|");
            Console.WriteLine("| 2. Inserir Série..............................................|");
            Console.WriteLine("| 3. Atualizar Série............................................|");
            Console.WriteLine("| 4. Excluir Série..............................................|");
            Console.WriteLine("| 5. Visualizar Série...........................................|");
            Console.WriteLine("| C. Limpar Tela................................................|");
            Console.WriteLine("| X. Sair.......................................................|");
            Console.WriteLine("+===============================================================+");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            //Console.WriteLine();
            return opcaoUsuario;
        }
    }
}