using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Entidades
{
    public class Pauta
    {
        public string Nome { get; set; }
        public int Id { get; set; }
       static public List<Eleitor> Eleitores { get; set; }

        public Pauta() { }
        public Pauta(string nome, int id, List<Eleitor> eleitores)
        {
            Nome = nome;
            Id = id;
            Eleitores = eleitores;
        }
        public Pauta(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }
        
       static public void Mostra()
        {
            Console.WriteLine("Nome dos Eleitores");
            foreach (var item in Eleitores)
            {
                Console.WriteLine($"Nome: {item.Nome} Cod: {item.CodEleitor}\n");
            }
        }
        public void Add(Eleitor eleitor)
        {
            Eleitores.Add(eleitor);
        }
        
    }
}
