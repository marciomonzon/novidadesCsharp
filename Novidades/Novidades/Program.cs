using System;

namespace Novidades
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 **** Range Index
            string[] cursos = new string[] { "asp.net", "C#", "Angular", "Java" };
            foreach (var item in cursos[0..3]) // 3 posições
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine();
            Console.ReadKey();


            // 2 FUNÇÕES LOCAIS ESTATICAS
            // a diferença é o escopo de a e b. São locais da função Soma
            Console.WriteLine(Soma(5, 5));
            static int Soma(int a, int b) => a + b;

            Console.WriteLine();
            Console.ReadKey();

            // 3 NOVA FORMA DE FAZER SWITCH
            var operador = "*";
            var resultado = operador switch
            {
                "-" => "Subtrair",
                "+" => "Adição",
                "*" => "Multiplicação",
                "/" => "Divisão"
            };
            Console.WriteLine(resultado);
            Console.WriteLine();
            Console.ReadKey();

            // 4 SWITCH COM TUPLAS
            Console.WriteLine(RecuperarResultado((Resultado.Positivo, Resultado.Positivo), false));
            Console.WriteLine();
            Console.ReadKey();


            // 5 usings
            // ele já entende que no final vai dar um dispose
            using var file = new System.IO.StreamWriter("file.txt");


            // bonus de versões anteriores

            // 6 COALESCE
            int? numero = null;
            int numero2 = numero ?? -1; // se o primeiro for null, atribui o segundo
            Console.WriteLine(numero2);
            Console.WriteLine();
            Console.ReadKey();

            // 7 NULL CONDITIONAL C# 6 ou 7
            dynamic pessoa = new
            {
                Cabeca = "grande",
                Mao = "pequena",
                Pes = "medios"
            };


            if (pessoa.Cabeca == "grande")
            {
                Console.WriteLine("Cabeça grande");
            }
            else
            {
                Console.WriteLine("Cabeça normal");
            }

            pessoa = null;

            if (pessoa?.Cabeca == "grande")
            {
                Console.WriteLine("Cabeça grande");
            }
            else
            {
                Console.WriteLine("Cabeça normal");
            }

            Console.WriteLine();
            Console.ReadKey();

            // 8 DESCARTES
            var (nome, sobrenome) = RetornarNomeSobreNome();
            Console.WriteLine($"{nome} {sobrenome}");

            // o underline é o descarte
            var (nome2, _) = RetornarNomeSobreNome();
            Console.WriteLine($"{nome2}");

            Console.WriteLine();
            Console.ReadKey();
        }

        // retorno de tuplas
        public static (string, string) RetornarNomeSobreNome() => ("Jose", "Beltrando");

        public static Resultado RecuperarResultado((Resultado, Resultado) result, bool perigo = false)
        {
            return result switch
            {
                (Resultado.Positivo, Resultado.Positivo) when perigo => Resultado.Negativo,
                (Resultado.Positivo, Resultado.Positivo) when !perigo => Resultado.Positivo,
                (_, _) => Resultado.Negativo
            };  
        }

        public enum Resultado
        {
            Positivo,
            Negativo
        }
    }
}
