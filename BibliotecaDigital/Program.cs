using System;
using BibliotecaDigital.Models;
using BibliotecaDigital.Services;

namespace BibliotecaDigital;
class Program
{
    public static void Main(string[] args)
    {
        ExibirMenu();
        string op = Console.ReadLine();
        int opInt = Convert.ToInt32(op);
        BibliotecaService biblioteca = new BibliotecaService();

        while(opInt > 0)
        {
            if(opInt == 1)
            {
                Console.Write("\nDigite o título do livro: ");
                string titulo = Console.ReadLine();

                Console.Write("Digite o nome do autor do livro: ");
                string autor = Console.ReadLine();

                Console.Write("Digite o ano do livro: ");
                string ano = Console.ReadLine();
                int anoInt = Convert.ToInt32(ano);

                Console.Write("Disponível (S/N): ");
                string disponivel = Console.ReadLine();
                bool status = disponivel.Equals("S".ToUpper()) ? true : false;

                Livro livro = new Livro(titulo, autor, anoInt, status);
                biblioteca.AdicionarLivro(livro);
                Thread.Sleep(5000);
                Console.Clear();
                ExibirMenu();
            }
        };
    }

    static void ExibirMenu()
    {
        Console.WriteLine("Bem-Vindo!");
        Console.WriteLine("\nDigite o Número da Opção Desejada: ");
        Console.WriteLine("1. Adicionar Livro");
        Console.WriteLine("2. Listar Livros");
        Console.WriteLine("3. Atualizar Livro");
        Console.WriteLine("4. Remover Livro");
        Console.WriteLine("5. Sair");
    }
}