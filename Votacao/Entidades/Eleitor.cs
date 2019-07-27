using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Entidades
{
    public class Eleitor
    {
        public string Nome { get; set; }
        public int CodEleitor { get; set; }

        public Eleitor() {}

        public Eleitor(string nome, int codEleitor)
        {
            Nome = nome;
            CodEleitor = codEleitor;
        }
    }
   
}
