using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace TestesLinq2
{
    public class Cidade
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
    }

    class Program
    {
        static void ExibirResultado(string tipoTeste,
            IEnumerable<Cidade> cidades)
        {
            Console.WriteLine();
            Console.WriteLine($"*** {tipoTeste} ***");
            Console.WriteLine();
            
            Console.WriteLine($"No. de elementos: {cidades.Count()}");
            Console.WriteLine();
            
            Console.WriteLine($"Dados: {JsonSerializer.Serialize(cidades)}");
            Console.WriteLine();

            Console.WriteLine("Cidades:");
            foreach (var cidade in cidades)
                Console.WriteLine($"  * {cidade.Nome}-{cidade.Estado}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var cidades1 = new Cidade[]{
                new () { Nome = "Sao Paulo", Estado = "SP" },
                new () { Nome = "Rio de Janeiro", Estado = "RJ" },
                new () { Nome = "Belo Horizonte", Estado = "MG" }
            };

            var cidades2 = new Cidade[]{
                new () { Nome = "Belo Horizonte", Estado = "MG" },
                new () { Nome = "Sao Paulo", Estado = "SP" },
                new () { Nome = "Porto Alegre", Estado = "RS" },
                new () { Nome = "Salvador", Estado = "BA" },
            };

            var cidadesUnionBy = cidades1.UnionBy(cidades2, c => c.Nome);
            ExibirResultado("Testes com UnionBy (propriedade Nome)", cidadesUnionBy);

            var cidadesIntersectBy = cidades1.IntersectBy(
                cidades2.Select(c2 => c2.Nome),  c => c.Nome);
            ExibirResultado("Testes com IntersectBy (propriedade Nome)", cidadesIntersectBy);

        }
    }
}