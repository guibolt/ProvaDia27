using System;
using System.Collections.Generic;
using System.Text;

namespace Votacao.Entidades
{
    public class Votar
    {
        public Pauta Pauta { get; set; }
        public int VotosF { get; set; }
        public int VotosC { get; set; }
        public bool Resultado { get; set; }
        public string Aprovado { get; set; }
        public int Eleitores { get; set; }
        public int pAFavor { get; set; }
        public int pContra { get; set; }

        public Votar(Pauta pauta)
        {
            Pauta = pauta;
        }

        public void Votars()
        {
            Console.WriteLine($"VOTACAO: PAUTA {Pauta.Nome} ID {Pauta.Id}");
            foreach (var eleitor in Pauta.Eleitores)
            {
                Console.WriteLine($"{eleitor.Nome} voce Deseja Votar a Favor ou contra a ? F para a favor e C para contra");
                string voto = Console.ReadLine().ToUpper();
                if (voto == "F")
                {
                    VotosF++;
                }
                else
                {
                    VotosC++;
                }
                Eleitores++;

                Decidir();
            }
            Porc();
        }
        public void Decidir()
        {
            if (VotosF > VotosC)
            {
                 Aprovado = "Sim!";
                Console.WriteLine($"O Resultado da pauta foi {Aprovado}");
                Resultado = true;
            }
            else
            {
                Aprovado = "Não!";
                Console.WriteLine($"O Resultado da pauta foi {Aprovado}");
                Resultado = false;
            }
        }
       
        public void Porc()
        {
           pAFavor = (VotosF / Eleitores) * 100;
           pContra = (VotosC / Eleitores) * 100;
            Console.WriteLine($" Votos a favor {pAFavor} %");
            Console.WriteLine($"Votos Votos Contra {pContra} %");
        }

    }

}
