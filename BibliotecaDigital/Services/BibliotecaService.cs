using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BibliotecaDigital.Models;

namespace BibliotecaDigital.Services;

public class BibliotecaService
{
    public BibliotecaService()
    {
        // Ao iniciar, tenta carregar os livros salvos
        CarregarDados();
    }

    private List<Livro> livros = new List<Livro>();
    private static int contadorId = 1; // Inicia em 1
    private readonly string caminhoArquivo = "C:\\Teste\\Biblioteca\\biblioteca.json";

    public void AdicionarLivro(Livro livro)
    {
        livro.Id = contadorId;
        contadorId++;
        livros.Add(livro);
        SalvarDados(); // Atualiza o arquivo JSON
        Console.WriteLine($"\nO livro {livro.Titulo} foi adicionado com sucesso.");
    }

    public void ListarLivros()
    {
        CarregarDados();
        Console.WriteLine("Lista de livros: ");

        foreach(var livro in livros)
        {
            Console.WriteLine($"\nId: {livro.Id}. Título: {livro.Titulo}. Autor: {livro.Autor}, Ano: {livro.Ano}, Disponível: {livro.Disponivel}");
        }
    }

    public void AtualizarLivro()
    {
        Livro livroRetorno = new Livro();
        CarregarDados();
        Console.WriteLine("Para atualizar as informações do livro forneça os seguintes dados: ");
        Console.WriteLine("Digite o ID do livro");
        int id = Convert.ToInt32(Console.ReadLine());

        // Percorre a lista de livros para selecionar o livro pelo ID
        foreach (var livro in livros)
        {
            if(livro.Id == id)
            {
                livroRetorno = AtualizaInformacoesLivro(livro);
                livro.Titulo = livroRetorno.Titulo;
                livro.Autor = livroRetorno.Autor;
                livro.Ano = livroRetorno.Ano;
                livro.Disponivel = livroRetorno.Disponivel;
                break;
            }
        }

        SalvarDados();
        Console.WriteLine($"O livro {livroRetorno.Titulo} foi atualizado com sucesso.");
    }

    public void RemoverLivro(int id)
    {
        string titulo = "";
        foreach(var livro in livros)
        {
            if(livro.Id == id)
            {
                titulo = livro.Titulo;
                livros.Remove(livro);
                continue;
            }
        }

        Console.WriteLine($"O livro {titulo} foi removido com sucesso.");
    }

    private void SalvarDados()
    {
        try
        {
            var opcoes = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Permite caracteres acentuados
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(livros, opcoes);
            File.WriteAllText(caminhoArquivo, json);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }    
    }

    private void CarregarDados()
    {
        if(File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            livros = JsonSerializer.Deserialize<List<Livro>>(json) ?? new List<Livro>();

            // Atualiza o contador de ID para continuar do último
            if(livros.Any())
            {
                contadorId = livros.Max(x => x.Id) + 1;
            }
        }
    }

    static Livro AtualizaInformacoesLivro(Livro livroAtualizado)
    {
        try
        {
            List<int> camposAtualizacao = new List<int>();
            int campo;
            Console.WriteLine("\nDigite o(s) número(s) do(s) campo(s) você deseja atualizar: ");
            Console.WriteLine("\n1-Título\n2-Autor\n3-Ano\n4-Disponível\nDigite 5 para continuar com a atualização");

            do
            {
                campo = Convert.ToInt32(Console.ReadLine());

                if (campo >= 1 && campo <= 4)
                {
                    camposAtualizacao.Add(campo);
                }
            } while (campo != 5);

            foreach (int item in camposAtualizacao)
            {
                if (item == 1)
                {
                    Console.WriteLine("\nDigite o Título atualizado: ");
                    livroAtualizado.Titulo = Console.ReadLine();
                }
                else if (item == 2)
                {
                    Console.WriteLine("\nDigite o nome do Autor atualizado: ");
                    livroAtualizado.Autor = Console.ReadLine();
                }
                else if (item == 3)
                {
                    Console.WriteLine("\nDigite o ano atualizado: ");
                    livroAtualizado.Ano = Convert.ToInt32(Console.ReadLine());
                }
                else if (item == 4)
                {
                    Console.WriteLine("\nDigite se o livro está disponível (Sim/Não): ");
                    livroAtualizado.Disponivel = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Campo não existe para atualizar!");
                }
            }

            return livroAtualizado;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}
