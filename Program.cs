using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static RepositorioFilmes repositorioFilme = new RepositorioFilmes();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = "";
            string filme_Serie = "";
            do
            {
                Console.WriteLine("Deseja manipular filmes(0) ou Séries(1)?");
                filme_Serie = Console.ReadLine();
                if (filme_Serie == "1")
                {
                    opcaoUsuario = ObterOpcaoUsuario().ToUpper();
                    switch ((opcaoUsuario))
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
                        case "E":
                            ExportarCsvSeries("");
                            break;
                        case "X":
                            Console.WriteLine("Saindo do programa");
                            break;
                        default:
                            Console.WriteLine("Opção inexistente");
                            break;
                    }
                }
                else if (filme_Serie == "0")
                {
                    opcaoUsuario = ObterOpcaoUsuarioFilme().ToUpper();
                    switch ((opcaoUsuario))
                    {
                        case "1":
                            ListarFilmes();
                            break;
                        case "2":
                            InserirFilme();
                            break;
                        case "3":
                            AtualizarFilme();
                            break;
                        case "4":
                            ExcluirFilme();
                            break;
                        case "5":
                            VisualizarFilme();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        case "E":
                            ExportarCsvFilmes("");
                            break;
                        case "X":
                            Console.WriteLine("Saindo do programa");
                            break;
                        default:
                            Console.WriteLine("Opção inexistente");
                            break;
                    }
                }
                else {
                    Console.WriteLine("Opção inexistente");
                }
            } while (opcaoUsuario != "X");
            Environment.Exit(0);
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma Série foi cadastrada.");
                return;
            }
            foreach (var i in lista) {
                if (!i.getExcluido())
                {
                    Console.WriteLine("ID:{0} - {1} ", i.RetorneId(), i.RetornaTitulo());
                }
            }
        }
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Bem Vindo ao nosso serviço de Séries");
            Console.WriteLine("Escolha uma das opções abaixo, por número,informando com o que podemos ajuda-l(x):");
            Console.WriteLine("1 - Listar minhas séries cadastradas.");
            Console.WriteLine("2 - Adicionar uma nova série.");
            Console.WriteLine("3 - Atualizar uma de minhas séries.");
            Console.WriteLine("4 - Excluir uma de minhas séries.");
            Console.WriteLine("5 - Visualizar série.");
            Console.WriteLine("C - limpar o terminal.");
            Console.WriteLine("E - Exportar Minhas Séries para series.csv.");
            Console.WriteLine("X - Sair do programa.");
            string x = Console.ReadLine();
            return x;
        }
        private static void InserirSerie() {
            Console.WriteLine("Inserir nova Série");
            int gen;
            
            Console.WriteLine("Digite o titulo da série:");
            string titulo = Console.ReadLine();

            foreach (int item in Enum.GetValues(typeof(Genero))) {
                  Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }
            Console.WriteLine("Escolha um dos Gêneros acima");
            gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano de estréia da série:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite uma descricao para a série:");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)(gen),
                                        titulo:titulo,
                                        descricao:descricao,
                                        ano:ano);
            repositorio.Insere(novaSerie);
            Console.WriteLine("Série cadastrada com sucesso.\n");
        }
        private static void AtualizarSerie() {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorio.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            Console.WriteLine("Inserir nova Série");
            int gen;
            
            Console.WriteLine("Digite o titulo da série:");
            string titulo = Console.ReadLine();

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }
            Console.WriteLine("Escolha um dos Gêneros acima");
            gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano de estréia da série:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite uma descricao para a série:");
            string descricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: indice,
                                        genero: (Genero)(gen),
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            repositorio.Atualizar(indice,novaSerie);
            Console.WriteLine("Série atualizada com sucesso.\n");
        }
        private static void ExcluirSerie() {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorio.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            repositorio.Excluir(indice);
        }
        private static void VisualizarSerie() {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorio.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            var serie = repositorio.RetornaPorId(indice);
            Console.WriteLine(serie);
        }






        private static void ListarFilmes()
        {
            Console.WriteLine("Listar filmes");
            var lista = repositorioFilme.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme foi cadastrado.");
                return;
            }
            foreach (var i in lista)
            {
                if (!i.GetExcluido())
                {
                    Console.WriteLine("ID:{0} - {1} ", i.GetId(), i.GetTitulo());
                }
            }
        }
        private static string ObterOpcaoUsuarioFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Bem Vindo ao nosso serviço de Filmes");
            Console.WriteLine("Escolha uma das opções abaixo, por número,informando com o que podemos ajuda-l(x):");
            Console.WriteLine("1 - Listar meus filmes cadastrados.");
            Console.WriteLine("2 - Adicionar um novo filme.");
            Console.WriteLine("3 - Atualizar um de meus filmes.");
            Console.WriteLine("4 - Excluir um de meus filmes.");
            Console.WriteLine("5 - Visualizar filmes.");
            Console.WriteLine("C - limpar o terminal.");
            Console.WriteLine("E - Exportar Meus filmes para filmes.csv.");
            Console.WriteLine("X - Sair do programa.");
            string x = Console.ReadLine();
            return x;
        }
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo Filme");
            int gen;

            Console.WriteLine("Digite o titulo do filme:");
            string titulo = Console.ReadLine();

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }
            Console.WriteLine("Escolha um dos Gêneros acima");
            gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano do filme:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite uma descricao para o filme:");
            string descricao = Console.ReadLine();

            List<Genero> g = new List<Genero>();
            g.Add((Genero)gen);

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: g,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            repositorioFilme.Insere(novoFilme);
            Console.WriteLine("Filme cadastrado com sucesso.\n");
        }
        private static void AtualizarFilme()
        {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorioFilme.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            Console.WriteLine("Inserir novo filme");
            int gen;

            Console.WriteLine("Digite o titulo do filme:");
            string titulo = Console.ReadLine();

            foreach (int item in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", item, Enum.GetName(typeof(Genero), item));
            }
            Console.WriteLine("Escolha um dos Gêneros acima");
            gen = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ano do filme:");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite uma descrição para o filme:");
            string descricao = Console.ReadLine();
            List<Genero> g = new List<Genero>();
            g.Add((Genero)gen);

            Filme novoFilme = new Filme(id: indice,
                                        genero: g,
                                        titulo: titulo,
                                        descricao: descricao,
                                        ano: ano);
            repositorioFilme.Atualizar(id:indice,entidade:novoFilme);
            Console.WriteLine("Filme atualizado com sucesso.\n");
        }
        private static void ExcluirFilme()
        {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorio.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            repositorioFilme.Excluir(indice);
        }
        private static void VisualizarFilme()
        {
            Console.WriteLine("Informe o ID:");
            int indice = int.Parse(Console.ReadLine());
            if (indice > repositorio.Tamanho())
            {
                Console.WriteLine("Registro não existe");
                return;
            }
            var filme = repositorioFilme.RetornaPorId(indice);
            Console.WriteLine(filme);
        }
        private static void ExportarCsvSeries(string local) {
            string path = @"C:/Users/diego/source/repos/Series/series.csv";//local
            string delimitter = ", ";
            string docText = "Titulo" + delimitter + "Ano" + delimitter + "genero"+delimitter+Environment.NewLine;
            
            foreach (Serie i in repositorio.Lista())
            {
                 docText = docText + i.getTitulo() + delimitter + i.getAno()
                     + delimitter + i.getGenero().ToString() + delimitter + Environment.NewLine;
            }
            File.WriteAllText(path, docText);
        }
        private static void ExportarCsvFilmes(string local)
        {
            string path = @"C:/Users/diego/source/repos/Series/filmes.csv";//local
            string delimitter = ", ";
            string docText = "Titulo" + delimitter + "Ano" + delimitter + "genero" + delimitter + Environment.NewLine;

            foreach (Filme i in repositorioFilme.Lista())
            {
                docText = docText + i.GetTitulo() + delimitter + i.GetAno()
                    + delimitter + i.GetGenero().ToString() + delimitter + Environment.NewLine;
            }
            File.WriteAllText(path, docText);
        }
    }

}

