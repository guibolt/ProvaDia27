using System;
using System.Collections.Generic;
using Votacao.Entidades;
using System.Linq;
namespace Votacao
{
    class Program
    {
        static void Main(string[] args)
        {
            var Votar = new List<Votar>();
            var Eleitores = new List<Eleitor>();
            var Pautas = new List<Pauta>();

            while (true)
            {
                Console.WriteLine("PRESSIONE |1| PARA CADASTRO DE ELEITORES\n|2| PARA CADASTRO DE PAUTAS\n|3| PARA AS MOSTRAR PAUTAS \n|4|PARA LISTAR A BASE DE ELEIOTRES \n|5| PARA VINCULAR \n|6| PARA LISTAR O RESULTADO DE PAUTAS FINALIZADAS  \n |7| PARA INICIAR A VOTAÇÃO \n PRESSIONE |8| PARA SAIR");
                Int32.TryParse(Console.ReadLine(), out int decisao);

                switch (decisao)
                {
                    case 1:
                        Console.WriteLine("Cadastro de Eleitores");
                        Console.WriteLine("Quantos eleitores deseja cadastrar ?");
                        Int32.TryParse(Console.ReadLine(), out int N);

                        for (int i = 0; i < N; i++)
                        {
                            Console.WriteLine("Insira o nome");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o Codigo do Eleitor");
                            int cod = int.Parse(Console.ReadLine());
                            Eleitores.Add(new Eleitor(nome, cod));
                        }
                        break;

                    case 2:

                        Console.WriteLine("CADASTRO DE PAUTAS");

                        Console.WriteLine("Quantas pautas? deseja cadastrar ?");
                        Int32.TryParse(Console.ReadLine(), out N);
                        for (int i = 0; i < N; i++)
                        {
                            var EleitoresPauta = new List<Eleitor>();
                            Console.WriteLine("Insira o nome da pauta");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o codigo da pauta");
                            int cod = int.Parse(Console.ReadLine());


                            Console.WriteLine("Deseja cadastrar Eleitores ? s para sim e n para nao");
                            string dd = (Console.ReadLine().ToLower());
                            if (dd == "s")
                            {
                                Console.WriteLine("Esses sao os eleitores disponiveis para a votação nessa pauta");
                                Eleitores.ForEach(E => Console.WriteLine($"Nome: {E.Nome} Codigo Eleitor {E.CodEleitor}"));

                                Console.WriteLine("Quantos eleitores deseja adcionar nessa pauta ?");

                                Int32.TryParse(Console.ReadLine(), out N);
                                for (int j = 0; j < N; j++)
                                {
                                    if (Eleitores.Count < 1)
                                    {
                                        Console.WriteLine("Não há eleitores disponiveis");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Se Beaseando no cod de eleitor, escolha o eleitor para entrar na pauta");
                                        int Cod = int.Parse(Console.ReadLine());
                                        var eleitor = Eleitores.Find(c => c.CodEleitor == Cod);

                                        EleitoresPauta.Add(eleitor);
                                    }


                                }
                                Pautas.Add(new Pauta(nome, cod, EleitoresPauta));
                            }
                            else
                            {
                                Pautas.Add(new Pauta(nome, cod));
                            }


                        }
                        break;

                    case 3:
                        if (Pautas.Count == 0)
                        {
                            Console.WriteLine("Não há pautas disponiveis");
                        }
                        else
                        {
                            foreach (var item in Pautas)
                            {
                                Console.WriteLine($"Codigo da pauta{item.Id} Nome da pauta {item.Nome}\n");

                                Console.WriteLine("Lista de eleitores nessa pauta\n");
                               Pauta.Mostra();
                            }
                        }

                        break;

                    case 4:

                        if (Eleitores.Count == 0)
                        {
                            Console.WriteLine("Não tem eleitores cadastrados\n");
                        }
                        else
                        {
                            Console.WriteLine("Lista de eleitores cadastrados\n");

                            Eleitores.ForEach(e => Console.WriteLine($"Nome: {e.Nome} Cod: {e.CodEleitor}\n"));
                        }

                        break;

                    case 5:
                        Pautas.ForEach(c => Console.WriteLine($"Nome da pauta: {c.Nome} Codigo: {c.Id} "));
                        Console.WriteLine("Qual pauta voce quer vincular? selecione pelo codigo");
                        int co = int.Parse(Console.ReadLine());
                        var pauta = Pautas.Find(p => p.Id == co);

                        Console.WriteLine("Agora selecione o eleitor pelo codigo a adiconar na pauta");
                        Eleitores.ForEach(e => Console.WriteLine($"Nome: {e.Nome} Cod: {e.CodEleitor}\n"));
                        int el = int.Parse(Console.ReadLine());
                        var eleitors = Eleitores.Find((c => c.CodEleitor == el));


                        Console.ReadLine();
                        pauta.Add(eleitors);
                        break;

                    case 6:
                        Console.WriteLine("Qual pauta voce deseja Votar? fale pelo codigo");
                        foreach (var item in Pautas)
                        {
                            Console.WriteLine($"Codigo da pauta: {item.Id} Nome da pauta: {item.Nome}\n");

                        }
                        int codp = int.Parse(Console.ReadLine());
                        var pautaAS = Pautas.Find(p => p.Id == codp);
                        Votar V = new Votar(pautaAS);
                        V.Votars();

                        Votar.Add(V);
                        break;

                    default:
                        decisao = 0;
                        break;

                }



            }
        }
    }
}
