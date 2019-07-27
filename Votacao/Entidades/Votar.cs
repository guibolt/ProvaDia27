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
        public bool Status { get; set; }
        public string Aprovado { get; set; }


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
                string voto = Console.ReadLine().ToLower();
                if (voto == "F")
                {
                    VotosF++;
                }
                else
                {
                    VotosC++;
                }


                Decidir();
            }
        }


        public void Decidir()
        {
            if (VotosF > VotosC)
            {
                 Aprovado = "Sim!";
                Console.WriteLine(Aprovado);
            }
            else
            {
                Aprovado = "Não!";
                Console.WriteLine(Aprovado);
            }
        }

        public int porc()
        {
            return 0;
        }


    }

}
