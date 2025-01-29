using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDigital.Models;

namespace BibliotecaDigital.Services;

public class BibliotecaService
{
    private List<Livro> livros = new List<Livro>();
    private static int contadorId = 1; // Inicia em 1

    public void AdicionarLivro(Livro livro)
    {
        livro.Id = contadorId;
        contadorId++;
        livros.Add(livro);
        Console.WriteLine($"O livro {livro.Titulo} foi adicionado com sucesso.");
    }

    public void ListarLivros(List<Livro> livros)
    {
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
}
