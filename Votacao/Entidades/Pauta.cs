using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Entidades
{
    public class Pauta
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public List<Eleitor> Eleitores { get; set; } = new List<Eleitor>();

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

       public void Mostra()
        {
            Console.WriteLine("Nome dos Eleitores");
            foreach (var item in Eleitores)
            {
                Console.WriteLine($"Nome: {item.Nome} Cod: {item.CodEleitor}\n");
            }
        }
         public void Add(List<Eleitor> eleitor)
        {
            Console.WriteLine("Agora selecione o eleitor pelo codigo a adiconar na pauta");
            eleitor.ForEach(e => Console.WriteLine($"Nome: {e.Nome} Cod: {e.CodEleitor}\n"));
            int el = int.Parse(Console.ReadLine());
            var ele = eleitor.Find((c => c.CodEleitor == el));
            Eleitores.Add(ele);
        }
    }
}
