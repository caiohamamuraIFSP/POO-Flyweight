using System;
using System.Collections.Generic;
using System.IO;

namespace ProxyCacheExtenso
{
    class Program
    {
        static void Main(string[] args)
        {
            IConverteExtenso leitoraExtenso = new LeitoraExtenso();
            leitoraExtenso = new CacheExtenso(leitoraExtenso);
            Console.WriteLine(leitoraExtenso.ConverterExtenso(1));
            Console.WriteLine(leitoraExtenso.ConverterExtenso(2));
            Console.WriteLine(leitoraExtenso.ConverterExtenso(3));
            Console.WriteLine(leitoraExtenso.ConverterExtenso(4));


            Console.WriteLine(leitoraExtenso.ConverterExtenso(2));
            Console.WriteLine(leitoraExtenso.ConverterExtenso(3));

            leitoraExtenso = new LeitoraExtenso();
            leitoraExtenso = new CacheExtenso(leitoraExtenso);
            Console.WriteLine(leitoraExtenso.ConverterExtenso(1));
            Console.WriteLine(leitoraExtenso.ConverterExtenso(2));
        }
    }

    // Crie uma interface para a classe que deseja criar o Cache
    public interface IConverteExtenso 
    {
        public string ConverterExtenso(int numero);
    }

    // Crie uma classe Cache derivando a interface
    public class CacheExtenso : IConverteExtenso
    {
        static private Dictionary<int, string> cacheDicionario = new Dictionary<int, string>();

        // Manter como atributo o objeto original
        private IConverteExtenso conversorOriginal;

        private CacheExtenso() {}

        // No construtor do Cache aceitar um objeto da interface
        public CacheExtenso(IConverteExtenso conversor)
        {
            conversorOriginal = conversor;
        }

        public string ConverterExtenso(int numero)
        {
            // Verificar se a requisição já existe no Dictionary
            if (cacheDicionario.ContainsKey(numero))
            {
                Console.Write("Retornando valor da memória... ");
                // Se existir apenas capturar o valor
                return cacheDicionario[numero];
            }
            else 
            {
                // Se não existir redirecionar a requisição para o objeto original
                string resultado = conversorOriginal.ConverterExtenso(numero);
                cacheDicionario.Add(numero, resultado);
                return resultado;
            }
        }
    }

    // Implemente a interface na classe original
    public class LeitoraExtenso: IConverteExtenso
    {
        public LeitoraExtenso() {}

        public string ConverterExtenso(int numero)
        {
            string caminho = $"{numero}.txt";
            if (File.Exists(caminho))
            {
                Console.Write($"Lendo o arquivo {caminho}... ");
                return File.ReadAllText(caminho);
            }
            return "Não encontrado!";
        }
    }
}
