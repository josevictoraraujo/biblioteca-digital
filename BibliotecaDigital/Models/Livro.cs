using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital.Models;

public class Livro
{
    public Livro(string titulo, string autor, int ano, string disponivel)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
        Disponivel = disponivel;
    }

    public Livro()
    {

    }

    public int Id {  get; set; }
    public string Titulo {  get; set; }
    public string Autor {  get; set; }
    public int Ano {  get; set; }
    public string Disponivel {  get; set; }

}
