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
    private readonly string caminhoArquivo = "C:\\Curso\\C#\\biblioteca.json";

    public void AdicionarLivro(Livro livro)
    {
        livro.Id = contadorId;
        contadorId++;
        livros.Add(livro);
        SalvarDados(); // Atualiza o arquivo JSON
        Console.WriteLine($"O livro {livro.Titulo} foi adicionado com sucesso.");
    }

    public void ListarLivros()
    {
        CarregarDados();
        Console.WriteLine("Lista de livros: ");

        foreach(var livro in livros)
        {
            Console.WriteLine($"Id: {livro.Id}. Título: {livro.Titulo}. Autor: {livro.Autor}, Ano: {livro.Ano}, Disponível: {livro.Disponivel}");
        }
    }

    public void AtualizarLivro(int id, Livro livroAtualizado)
    {
        // Percorre a lista de livros para selecionar o livro pelo ID
        foreach(var livro in livros)
        {
            if(livro.Id == id)
            {
                livro.Titulo = livroAtualizado.Titulo;
                livro.Autor = livroAtualizado.Autor;
                livro.Ano = livroAtualizado.Ano;
                livro.Disponivel = livroAtualizado .Disponivel;
                continue;
            }
            else
            {
                Console.WriteLine("Livro não encontrado. Verifique se o ID está correto.");
                return;
            }
        }

        Console.WriteLine($"O livro {livroAtualizado.Titulo} foi atualizado com sucesso.");
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
        string json = JsonSerializer.Serialize(livros, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoArquivo, json);
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
        else
        {
            File.Create(caminhoArquivo);
        }
    }
}
