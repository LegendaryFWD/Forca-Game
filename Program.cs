using System.Linq;
using System;
using System.IO;
namespace what
{
    class Program
    {
        static int vidas = 6;
        static char[] res;
        static string location = @"C:\AAAA";
        static string path = Path.Combine(location,"jogo");
        static string file = Path.Combine(path,"data.txt");
        static void Main(string[] args)
        {
            
            Console.WriteLine("Escreva a palavra que você quer jogar forca");
            string input = Console.ReadLine();
            forca(input);
            Directory.CreateDirectory(path);
            using (StreamWriter sw = File.AppendText(file))
            {       
                        sw.WriteLine(input);
            }       	
            Console.WriteLine("Você quer jogar novamente?[y,n]");
            Console.WriteLine("Digite h para ver seu histórico de palavras");
            string res = Console.ReadLine();
            while(true)
            {
                if(res == "y" || res == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Escreva a palavra que você quer jogar forca");
                    input = Console.ReadLine();
                    forca(input);
                    using (StreamWriter sw = File.AppendText(file))
                    {       
                        sw.WriteLine(input);
                    }       	
                    Console.WriteLine("Você quer jogar novamente?[y,n]");
                    Console.WriteLine("Digite h para ver seu histórico de palavras");
                    res = Console.ReadLine();
                }
                else if(res == "n" || res == "N")
                {
                    break;
                }
                else if(res == "h" || res == "H")
                {
                    Console.Clear();
                    var text = File.ReadAllText(file);
                    Console.WriteLine($"Histórico:");
                    Console.Write(text);
                    Console.Write("Você quer jogar novamente?[y,n]");
                    res = Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Você quer jogar novamente?[y,n]");
                    Console.WriteLine("Digite Y ou N");
                    res = Console.ReadLine();
                }
            }
        }



        static string check(string letra)
        {
             while(letra.Length > 1 || letra.Length == 0)
                {
                    Console.Clear();
                    Console.WriteLine(res);
                    Console.WriteLine("Escolha uma letra de verdade...");
                    vidas--;
                    Console.WriteLine($"Voce tem {vidas} vidas restantes");
                    letra = Console.ReadLine();

                }
            return letra;
        
        }
        
        static void forca(string input)
        {   
            vidas = 6;
            bool morreu = false;
            char[] palavra; 
            palavra = input.ToCharArray();
            res = new char[palavra.Length];
            for (int i = 0; i < palavra.Length; i++)
            {
               if(palavra[i] == ' ')
                {
                    res[i] = ' ';
                }
                else
                {
                    res[i] = '_';
                }
            }
        
            
            while(res.Contains('_'))
            {
                if(vidas == 0)
                {
                    Console.Clear();
                    Console.WriteLine("VOCE MORREU!");
                    return;
                }
                if (morreu == true)
                {
                    vidas--;
                }
                Console.Clear();
                Console.WriteLine(res);
                Console.WriteLine("Escolha uma letra...");
                Console.WriteLine($"Voce tem {vidas} vidas restantes");
                string letra = Console.ReadLine();
            
                letra = check(letra);

                while(res.Contains(Convert.ToChar(letra)))
                {
                    if(vidas == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("VOCE MORREU!");
                        break;
                    }
                    vidas--;
                    Console.Clear();
                    Console.WriteLine(res);
                    Console.WriteLine("Pare de ser burro...");
                    Console.WriteLine($"Voce tem {vidas} vidas restantes");
                    letra = Console.ReadLine();
                    letra = check(letra);
                }
                for(int i = 0; i < palavra.Length;i++)
                {
                    if(palavra[i] == Convert.ToChar(letra.ToUpper()) || palavra[i] == Convert.ToChar(letra.ToLower()))
                    {
                        res[i] = palavra[i];
                        
                    }
                }
                if (res.Contains(Convert.ToChar(letra.ToUpper())))
                {
                    morreu = false;
                }
                else if (res.Contains(Convert.ToChar(letra.ToLower())))
                {
                    morreu = false;
                }
                else
                {
                    morreu = true;
                }
            }
            Console.Clear();
            Console.WriteLine($"A palavra era {input}");
            Console.WriteLine("YOU WIN");
        }

    }
}
