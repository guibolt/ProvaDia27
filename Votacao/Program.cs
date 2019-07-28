using System;
using System.Collections.Generic;
using Votacao.Entidades;
using System.IO;
using Newtonsoft.Json;
namespace Votacao
{
    class Program
    {


        static void Main(string[] args)
        {
            bool comecar = true;
            string Path = @"C:\Users\guibo\Desktop\Trbalho\ProvaDia27\Votacao\Arquiv\ArquivoJson2.json";
            string caminho = @"C:\Users\guibo\Desktop\Trbalho\ProvaDia27\Votacao\Arquiv\Resultados.json";

            var Eleitores = new List<Eleitor>();
            var Votar = new List<Votar>();
            var Pautas = new List<Pauta>();


            using (StreamReader s = File.OpenText(Path))
            {
                string[] lines = File.ReadAllLines(Path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<Pauta>(line);
                    Pautas.Add(paut);
                }

            }
            using (StreamReader s = File.OpenText(caminho))
            {
                string[] lines = File.ReadAllLines(caminho);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<Votar>(line);
                    Votar.Add(paut);
                }
            }

            while (comecar)
            {
                Console.WriteLine("PRESSIONE |1| PARA CADASTRO DE ELEITORES\n|2| PARA CADASTRO DE PAUTAS\n|3| PARA AS MOSTRAR PAUTAS \n|4|PARA LISTAR A BASE DE ELEIOTRES \n|5| PARA VINCULAR \n| \n 6| PARA INICIAR A VOTAÇÃO  7| PARA LISTAR O RESULTADO DE PAUTAS FINALIZADAS  \n PRESSIONE |8| PARA SAIR");
                Int32.TryParse(Console.ReadLine(), out int decisao);

                switch (decisao)
                {
                    case 1:
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("CADASTRO DE PAUTAS");

                        Console.WriteLine("Quantas pautas? deseja cadastrar ?");
                        Int32.TryParse(Console.ReadLine(), out N);
                        for (int i = 0; i < N; i++)
                        {
                            // var EleitoresPauta = new List<Eleitor>();
                            Console.WriteLine("Insira o nome da pauta");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o codigo da pauta");
                            int cod = int.Parse(Console.ReadLine());
                            Pautas.Add(new Pauta(nome, cod));

                        }
                        break;

                    case 3:
                        Console.Clear();
                        foreach (var item in Pautas) { Console.WriteLine($"Codigo da pauta: {item.Id} Nome da pauta {item.Nome}\n"); }
                        break;

                    case 4:
                        Console.Clear();
                        foreach (var item in Pautas)
                        {
                            Console.WriteLine($"Codigo da pauta: {item.Id} Nome da pauta {item.Nome}\n");

                            Console.WriteLine("Lista de eleitores nessa pauta\n");
                            item.Mostra();
                        }
                        break;

                    case 5:
                        Console.Clear();
                        Pautas.ForEach(c => Console.WriteLine($"Nome da pauta: {c.Nome} Codigo: {c.Id} "));
                        Console.WriteLine("Qual pauta voce quer vincular? selecione pelo codigo");
                        int co = int.Parse(Console.ReadLine());
                        var pauta = Pautas.Find(pa => pa.Id == co);
                        pauta.Add(Eleitores);
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Qual pauta voce deseja Votar? fale pelo codigo");
                        foreach (var item in Pautas) { Console.WriteLine($"Codigo da pauta: {item.Id} Nome da pauta: {item.Nome}\n"); }
                        int codp = int.Parse(Console.ReadLine());
                        var pautaAS = Pautas.Find(pe => pe.Id == codp);
                        Votar V = new Votar(pautaAS);
                        V.Votars();
                        Votar.Add(V);
                        break;

                    case 7:
                        Console.Clear();
                        Votar.ForEach(vot => Console.WriteLine($"Pauta: {vot.Pauta.Nome} Eleitores {vot.Eleitores} Resultado {vot.Resultado} Votos Contra: {vot.VotosC} " +
                            $" Votos a Favor: {vot.VotosF}"));
                        break;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("obrigado e até a proxima");
                        comecar = false;
                        Console.ReadLine();
                        break;

                    default:
                        decisao = 0;
                        break;
                }

                File.Delete(Path);
                using (StreamWriter s = File.AppendText(Path))
                {
                    foreach (Pauta Vez in Pautas)
                    {
                        string G = JsonConvert.SerializeObject(Vez);
                        s.WriteLine(G);
                    }
                }
                File.Delete(caminho);
                using (StreamWriter s = File.AppendText(caminho))
                {
                    foreach (Votar vote in Votar)
                    {
                        string G = JsonConvert.SerializeObject(vote);
                        s.WriteLine(G);
                    }
                }
            }
        }

    }
}