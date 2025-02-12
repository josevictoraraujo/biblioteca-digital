using System;
using BibliotecaDigital.Models;
using BibliotecaDigital.Services;

namespace BibliotecaDigital;
class Program
{
    public static void Main(string[] args)
    {
        int opcao = ExibirMenu();
        BibliotecaService biblioteca = new BibliotecaService();

        while (opcao != 5)
        {
            if (opcao == 1)
            {
                Console.Write("\nDigite o título do livro: ");
                string titulo = Console.ReadLine();

                Console.Write("Digite o nome do autor do livro: ");
                string autor = Console.ReadLine();

                Console.Write("Digite o ano do livro: ");
                string ano = Console.ReadLine();
                int anoInt = Convert.ToInt32(ano);

                Console.Write("Disponível (Sim/Não): ");
                string disponivel = Console.ReadLine();

                Livro livro = new Livro(titulo, autor, anoInt, disponivel);
                biblioteca.AdicionarLivro(livro);
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                opcao = ExibirMenu();
            }
            else if (opcao == 2)
            {
                biblioteca.ListarLivros();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                opcao = ExibirMenu();
            }
            else if (opcao == 3)
            {
                biblioteca.AtualizarLivro();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                opcao = ExibirMenu();
            }
            else if(opcao == 4)
            {
                biblioteca.RemoverLivro();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                opcao = ExibirMenu();
            }
            else if(opcao == 5)
            {
                Console.WriteLine("\nA aplicação será encerrada em 5 segundos");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nOpção inválida. Digite o número de uma opção válida.");
                Thread.Sleep(3000);
                Console.Clear();
                opcao = ExibirMenu();
            }
        };
    }

    static int ExibirMenu()
    {
        Console.WriteLine("Bem-Vindo!");
        Console.WriteLine("\nDigite o Número da Opção Desejada: ");
        Console.WriteLine("\n1. Adicionar um Livro");
        Console.WriteLine("2. Exibir Livros");
        Console.WriteLine("3. Atualizar Livro");
        Console.WriteLine("4. Remover Livro");
        Console.WriteLine("5. Sair");
        string op = Console.ReadLine();
        int opInt = Convert.ToInt32(op);

        return opInt;
    }
}